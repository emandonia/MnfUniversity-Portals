using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace App_Code
{
    public static class ThemeManager
    {
        #region Theme-Related Method

        public static List<Theme> GetThemes()
        {
            var dInfo = new DirectoryInfo(
                HttpContext.Current.Server.MapPath("~/App_Themes"));
            DirectoryInfo[] dArrInfo = dInfo.GetDirectories();
            return dArrInfo.Select(sDirectory => new Theme(sDirectory.Name)).ToList();
        }

        #endregion Theme-Related Method
    }

    public class Theme
    {
        public Theme(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}