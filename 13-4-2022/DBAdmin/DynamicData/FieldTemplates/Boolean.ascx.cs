using System;
using System.Web.UI;

namespace DBAdmin
{
    public partial class BooleanField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get
            {
                return CheckBox1;
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            object val = FieldValue;
            if (val != null)
                CheckBox1.Checked = (bool)val;
        }
    }
}