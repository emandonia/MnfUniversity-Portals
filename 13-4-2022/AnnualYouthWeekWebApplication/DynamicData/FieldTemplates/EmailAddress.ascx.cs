﻿using System;
using System.Web.UI;

namespace DBAdmin
{
    public partial class EmailAddressField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get
            {
                return HyperLink1;
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            string url = FieldValueString;
            if (!url.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
            {
                url = "mailto:" + url;
            }
            HyperLink1.NavigateUrl = url;
        }
    }
}