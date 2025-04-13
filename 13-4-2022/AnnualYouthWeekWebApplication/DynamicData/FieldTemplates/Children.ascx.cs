using System;
using System.Web.UI;

namespace DBAdmin
{
    public partial class ChildrenField : System.Web.DynamicData.FieldTemplateUserControl
    {
        private bool _allowNavigation = true;
        private string _navigateUrl;

        public bool AllowNavigation
        {
            get
            {
                return _allowNavigation;
            }
            set
            {
                _allowNavigation = value;
            }
        }

        public override Control DataControl
        {
            get
            {
                return HyperLink1;
            }
        }

        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }

        protected string GetChildrenPath()
        {
            if (!AllowNavigation)
            {
                return null;
            }

            if (String.IsNullOrEmpty(NavigateUrl))
            {
                return ChildrenPath;
            }
            else
            {
                return BuildChildrenPath(NavigateUrl);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink1.Text = "View " + ChildrenColumn.ChildTable.DisplayName;
        }
    }
}