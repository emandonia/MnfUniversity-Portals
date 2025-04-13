using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using App_Code.Code;
using MnfUniversity_Portals.UserControls.Base;


namespace MnfUniversity_Portals.UserControls
{
    public partial class ResxEditor : UserControlBase
    {
        /// <summary>
        /// Add a culture info to the drop down of languages
        /// </summary>
        /// <param name="culture"></param>
        protected virtual void AddToLanguages(CultureInfo culture)
        {
            var displayname = culture.NativeName;
            ddLanguage.Items.Add(new ListItem(
                                     string.Format("{0} ", displayname),
                                     culture.Name)
                );
        }

        protected void btAddLang_Click(object sender, EventArgs e)
        {
            Unified.AddLanguage(ddLanguage.SelectedValue);
            FillLanguages();
            FillGridView();
        }

        /// <summary>
        /// Get all the Resx in the web site and list them in a list
        /// </summary>
        protected void GetResX()
        {
            SortedList<string, string> list = ResXUnified.GetResXInDirectory(Path,
                                                                             path =>
                                                                             path[0].Replace(path[1], "").Replace("App_LocalResources", "").Replace("App_GlobalResources", ""));

            foreach (KeyValuePair<string, string> val in list)
                lstResX.Items.Add(new ListItem(val.Key, val.Value));
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                var key = (string)row["Key"];
                var flagEmpty = false;

                for (var i = 1; i < gridView.Columns.Count; i++)
                {
                    string lang = ((BoundField)gridView.Columns[i]).DataField;
                    if (string.IsNullOrEmpty(Unified[lang][key])) continue;
                    flagEmpty = true;
                    break;
                }

                for (int i = 1; i < gridView.Columns.Count; i++)
                {
                    string lang = ((BoundField)gridView.Columns[i]).DataField;

                    if (string.IsNullOrEmpty(Unified[lang][key]) && flagEmpty)
                    {
                        ((TextBox)e.Row.Cells[i].Controls[0]).BackColor = Color.LightBlue;
                        ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onblur", "if (this.value.length==0) {this.style.backgroundColor='lightblue'; } else { this.style.backgroundColor='white'; } ");
                    }
                }
            }
        }

        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable table = Unified.ToDataTable(!chShowEmpty.Checked);

            string key = (string)table.Rows[e.RowIndex]["Key"];

            for (int i = 1; i < gridView.Columns.Count; i++)
            {
                var field = gridView.Columns[i] as BoundField;
                var txt = gridView.Rows[e.RowIndex].Cells[i].Controls[0] as TextBox;
                Unified[field.DataField][key] = txt.Text;
            }
        }

        protected void gridView_Saved(object sender, EventArgs e)
        {
            FillGridView();

            try
            {
                Unified.Save();

                MultiViewMsg.ActiveViewIndex = 0;
                lblMsg.Text += DateTime.Now.ToShortTimeString();
            }
            catch
            {
                MultiViewMsg.ActiveViewIndex = 1;
                lblMsg.Text = "Error while saving.";
            }

            pnlMsg.Visible = true;
        }

        /// <summary>
        /// The user changed the selected RESX file to edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lstResX_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFileName.Text = ResXUnified.GetBaseName(lstResX.SelectedValue);
            CurrentSelection = lstResX.SelectedValue;
            FillGridView(lstResX.SelectedValue, true);
            FillLanguages();
            btSave.Visible = true;
            pnlAddLang.Visible = true;
        }

        protected void OnShowEmpty(object sender, EventArgs e)
        {
            FillGridView();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetResX();
                FillLanguages();
            }
        }

        protected List<string> StringToList(string str)
        {
            List<string> toReturn = new List<string>();
            string[] splits = str.Split(',', ';');
            foreach (string split in splits)
                toReturn.Add(split.Trim().ToLowerInvariant());

            return toReturn;
        }

        private void FillGridView()
        {
            FillGridView(CurrentSelection, false);
        }

        private void FillGridView(string p, bool reloadFile)
        {
            if (Unified == null || reloadFile)
                Unified = new ResXUnified(p);

            gridView.Columns.Clear();

            var langs = Unified.GetLanguages();

            var columnSize = new Unit((gridView.Width.Value - 50) / (langs.Values.Count), UnitType.Pixel);

            var keyColumn = new ImageField
                                {
                                    HeaderText = "Key",
                                    DataAlternateTextField = "Key",
                                    DataImageUrlField = "Key",
                                    DataImageUrlFormatString = "~/styles/TranslationEditor/Images/information.png",
                                    ReadOnly = true
                                };

            keyColumn.ItemStyle.Width = new Unit(30);
            keyColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            keyColumn.ItemStyle.VerticalAlign = VerticalAlign.Middle;
            keyColumn.ControlStyle.Width = new Unit(16);
            gridView.Columns.Add(keyColumn);

            foreach (string lang in langs.Values)
            {
                var field = new BoundField();
                CultureInfo culture = null;
                try { culture = new CultureInfo(lang); }
                catch { }
                field.HeaderText = culture != null ? culture.NativeName : "Default";

                field.DataField = lang;
                field.ItemStyle.Width = columnSize;
                field.ControlStyle.Width = columnSize;

                gridView.Columns.Add(field);
            }

            gridView.DataSource = Unified.ToDataTable(!chShowEmpty.Checked);
            gridView.DataBind();
        }

        /// <summary>
        /// Fill the language drop down.  Either with a list of predefined cultures or from a list of default
        /// cultures from .NET.
        /// </summary>
        private void FillLanguages()
        {
            var langs = Unified != null ? Unified.GetLanguages() : new SortedList<string, string>();

            var cults = new SortedList<string, CultureInfo>();

            foreach (var language in StaticUtilities.OwnerNameTranslations(Page).Select(tr => tr.prtl_Language))
            {
                var cult = CultureInfo.CreateSpecificCulture(language.LCID).Parent;
                cults.Add(cult.DisplayName, cult);
            }

            ddLanguage.Items.Clear();

            foreach (CultureInfo culture in cults.Values)
            {
                if (!langs.ContainsKey(culture.Name))
                {
                    if (IncludeLanguages == "*" && ExcludeLanguages == "")
                        AddToLanguages(culture);
                    else
                    {
                        List<string> excludes = StringToList(ExcludeLanguages);
                        if (excludes.Contains(culture.Name.ToLowerInvariant()))
                            break;

                        if (IncludeLanguages == "*")
                            AddToLanguages(culture);
                        else
                        {
                            List<string> includes = StringToList(IncludeLanguages);
                            if (includes.Contains(culture.Name.ToLowerInvariant()))
                                AddToLanguages(culture);
                        }
                    }
                }
            }
        }

        //
        // Properties
        //

        #region Properties

        public string ExcludeLanguages
        {
            get
            {
                return GetViewStateValueOrDefault("ExcludeLanguages", "");
            }
            set
            {
                ViewState["ExcludeLanguages"] = value;
            }
        }

        public string IncludeLanguages
        {
            get
            {
                return GetViewStateValueOrDefault("IncludeLanguages", "*");
            }
            set
            {
                ViewState["IncludeLanguages"] = value;
            }
        }

        public string Path
        {
            get
            {
                return GetViewStateValueOrDefault("Path", Server.MapPath("~/"));
            }
            set
            {
                ViewState["Path"] = value;
            }
        }

        /// <summary>
        /// The current RESX file selected
        /// </summary>
        protected string CurrentSelection
        {
            get
            {
                return (string)ViewState["FilePath"];
            }
            set
            {
                ViewState["FilePath"] = value;
            }
        }

        protected ResXUnified Unified
        {
            get
            {
                return (ResXUnified)(ViewState["Unified"]);
            }
            set
            {
                ViewState["Unified"] = value;
            }
        }

        #endregion Properties
    }
}