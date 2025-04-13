using System;
using System.Collections.Specialized;
using System.Web.UI;

namespace DBAdmin
{
    public partial class Boolean_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get
            {
                return CheckBox1;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = CheckBox1.Checked;
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