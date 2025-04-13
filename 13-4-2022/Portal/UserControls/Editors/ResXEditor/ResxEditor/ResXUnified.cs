﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Resources;

namespace App_Code.Code
{
    public delegate R GenericPredicate<T, R>(params T[] obj);

    /// <summary>
    /// Represent a unified dictionnary of a bunch of ResX files.  For example
    /// Default.aspx.resx, Default.aspx.fr-CA.resx will be merged in an easy
    /// to access in memory dictionnary.  You can then change the values in
    /// memory and then save the changes back to disk later.
    /// </summary>
    [Serializable]
    public class ResXUnified
    {
        protected string baseFileName;
        protected string basePath;

        /// <summary>
        /// Files that changed since the last save
        /// </summary>
        protected List<string> changed = new List<string>();

        protected object lck = new object();

        /// <summary>
        /// Provide the path to the resx file name to load.
        /// The class will automatically find related files.
        /// </summary>
        /// <param name="filePath"></param>
        public ResXUnified(string filePath)
        {
            List<string> siblings = FindResXSiblings(filePath);

            foreach (string sibling in siblings)
                Languages.Add(FindCultureInFilename(sibling), ReadResX(sibling));

            baseFileName = GetBaseName(filePath);

            basePath = Path.GetDirectoryName(filePath);
        }

        #region Public Methods

        /// <summary>
        /// This is how to access the data.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public ResXUnifiedIndexer this[string language]
        {
            get
            {
                lock (lck)
                {
                    if (Languages.ContainsKey(language))
                        return new ResXUnifiedIndexer(this, language);
                    else
                        return new ResXUnifiedIndexer();
                }
            }
        }

        public void AddLanguage(string lang)
        {
            lock (Languages)
            {
                Languages.Add(lang, new Dictionary<string, string>());
                changed.Add(lang);
            }
        }

        /// <summary>
        /// Get a list of all the languages from this unified resx oject.
        /// </summary>
        /// <returns></returns>
        public SortedList<string, string> GetLanguages()
        {
            var keys = new SortedList<string, string>();
            lock (lck)
            {
                foreach (string key in Languages.Keys)
                    keys.Add(key, key);
            }

            return keys;
        }

        /// <summary>
        /// Save changes to disk made to this object.
        /// Files will be saved on the correct files.
        /// </summary>
        public void Save()
        {
            lock (lck)
            {
                foreach (string lang in changed)
                    WriteResX(GetFileName(lang), Languages[lang]);

                changed.Clear();
            }
        }

        /// <summary>
        /// Returns a DataTable wich is easy to diplay in a GridView.
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable(bool removeEmpty)
        {
            var table = new DataTable();
            table.Columns.Add("Key");

            lock (lck)
            {
                foreach (string lang in Languages.Keys)
                    table.Columns.Add(lang);

                foreach (string key in UnifiedKeys)
                {
                    bool isEmpty = false;
                    if (removeEmpty)
                        isEmpty = IsKeyEmpty(key);

                    if (!isEmpty)
                    {
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
                        row["Key"] = key;

                        foreach (string lang in Languages.Keys)
                            row[lang] = this[lang][key];
                    }
                }
            }

            return table;
        }

        public DataTable ToDataTable()
        {
            return ToDataTable(false);
        }

        /// <summary>
        /// Determine if the specified key have any value associated with it in any language.
        /// If it finds a value, it returns false, otherwise it returns true.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected bool IsKeyEmpty(string key)
        {
            bool isEmpty = true;
            foreach (string lang in Languages.Keys)
            {
                if (!string.IsNullOrEmpty(this[lang][key]))
                {
                    isEmpty = false;
                    break;
                }
            }
            return isEmpty;
        }

        #endregion Public Methods

        #region Utility Methods

        /// <summary>
        /// Simply find the culture string from the resx file name.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string FindCultureInFilename(string filename)
        {
            string file = filename.Substring(filename.IndexOf(GetBaseName(filename)) + GetBaseName(filename).Length + 1);

            // remove base name plus the dot.
            string[] split = file.Split('.');

            if (split.Length == 2)
                return split[0];
            else if (split.Length > 2)
                throw new Exception(
                    "Invalid base resx name. Filenames other than aspx/ascx/ashx/asmx/master are assumed not to contain any periods.");
            else
                return "Default";
        }

        /// <summary>
        /// Gets the path of a resx file and then returns the base
        /// file name for this resx.  For example for Default.aspx.fr-CA.resx,
        /// the base file name would be Default.aspx.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetBaseName(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower().EndsWith("resx"))
            {
                string file = Path.GetFileName(filePath);

                string[] split = file.Split('.');

                // assumption: filenames don't have . in them except if IsAspNetFile...
                if (IsAspNetFile(file))
                    return split[0] + "." + split[1];
                else
                    return split[0];
            }
            else
                return filePath;
        }

        public static SortedList<string, string> GetResXInDirectory(string basePath)
        {
            return GetResXInDirectory(basePath, null);
        }

        /// <summary>
        /// Returns a list of all the resx files contained recursivelly in the basePath directory passed.
        /// The
        /// </summary>
        /// <param name="basePath">Where do you want to search for .resx</param>
        /// <param name="display">A predicate function to modify the string to be displayed.  Can be null.</param>
        /// <returns></returns>
        public static SortedList<string, string> GetResXInDirectory(string basePath,
                                                                    GenericPredicate<string, string> display)
        {
            var dir = new DirectoryInfo(basePath);
            FileInfo[] files = dir.GetFiles("*.resx", SearchOption.AllDirectories);

            var dict = new SortedList<string, string>();

            foreach (FileInfo file in files)
            {
                string baseName = GetBaseName(file.FullName);
                string path = Path.GetDirectoryName(file.FullName);

                string displayName = display == null ? path : display(path, basePath);
                displayName = Path.Combine(displayName, baseName);
                if (!dict.ContainsKey(displayName))
                    dict.Add(displayName, file.FullName);
            }

            return dict;
        }

        /// <summary>
        /// Check in the same directory as the file and find related resx
        /// files that we can add to the unified object.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected List<string> FindResXSiblings(string filePath)
        {
            string basePath = Path.GetDirectoryName(filePath);

            string baseFileName = GetBaseName(filePath);

            var dir = new DirectoryInfo(basePath);
            FileInfo[] files = dir.GetFiles("*.resx", SearchOption.TopDirectoryOnly);

            var siblings = new List<string>();

            foreach (FileInfo file in files)
            {
                if (file.Name.StartsWith(baseFileName))
                    siblings.Add(file.FullName);
            }

            return siblings;
        }

        /// <summary>
        /// Returns the complete path of the resx of a language for the current resx we are editing
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        protected string GetFileName(string language)
        {
            if (language != "Default")
                return Path.Combine(basePath, baseFileName + "." + language + ".resx");
            else
                return Path.Combine(basePath, baseFileName + ".resx");
        }

        /// <summary>
        /// Open a ResX file and extract it's data.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        protected Dictionary<string, string> ReadResX(string filename)
        {
            var extracted = new Dictionary<string, string>();

            try
            {
                using (var reader = new ResXResourceReader(filename))
                {
                    foreach (DictionaryEntry entry in reader)
                        extracted.Add((string)entry.Key, (string)entry.Value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem loading ResX: " + filename + "." + ex.Message);
            }

            return extracted;
        }

        /// <summary>
        /// Write a ResX file to disk
        /// </summary>
        /// <param name="fileName"></param>
        protected void WriteResX(string fileName, Dictionary<string, string> dict)
        {
            try
            {
                using (var writer = new ResXResourceWriter(fileName))
                {
                    foreach (string key in dict.Keys)
                        writer.AddResource(key, dict[key]);
                    writer.Generate();
                }
            }
            catch
            {
                throw new Exception("Error while saving " + fileName);
            }
        }

        private static bool IsAspNetFile(string file)
        {
            return file.ToLower().Contains(".ascx.") || file.ToLower().Contains(".aspx.") ||
                   file.ToLower().Contains(".master.") || file.ToLower().Contains(".asmx.") ||
                   file.ToLower().Contains(".ashx.");
        }

        #endregion Utility Methods

        #region Properties

        protected Dictionary<string, Dictionary<string, string>> Languages =
            new Dictionary<string, Dictionary<string, string>>();

        protected List<string> unifiedKkeys = new List<string>();

        public List<string> UnifiedKeys
        {
            get
            {
                foreach (string lang in Languages.Keys)
                {
                    foreach (string key in Languages[lang].Keys)
                    {
                        if (!unifiedKkeys.Contains(key))
                            unifiedKkeys.Add(key);
                    }
                }

                return unifiedKkeys;
            }
        }

        #endregion Properties

        #region Indexer Class

        public class ResXUnifiedIndexer
        {
            protected string language;
            protected ResXUnified resx;

            public ResXUnifiedIndexer()
            {
            }

            public ResXUnifiedIndexer(ResXUnified resx, string language)
            {
                this.resx = resx;
                this.language = language;
            }

            public string this[string key]
            {
                get
                {
                    if (resx != null && resx.Languages[language].ContainsKey(key))
                        return resx.Languages[language][key];
                    else
                        return "";
                }
                set
                {
                    if (resx != null && resx.Languages[language].ContainsKey(key))
                    {
                        // Change it only if the two values are different
                        if (resx.Languages[language][key] != value)
                        {
                            // Mark the file as changed
                            resx.changed.Add(language);
                            resx.Languages[language][key] = value;
                        }
                    }
                    else if (resx != null && !resx.Languages[language].ContainsKey(key))
                    {
                        // Mark the file as changed
                        resx.changed.Add(language);
                        resx.Languages[language].Add(key, value);
                    }
                }
            }
        }

        #endregion Indexer Class

        //
        // Public Methods
        //

        //
        // Utility Methods
        //

        //
        // Properties
        //

        //
        // Indexer Class
        //
    }
}