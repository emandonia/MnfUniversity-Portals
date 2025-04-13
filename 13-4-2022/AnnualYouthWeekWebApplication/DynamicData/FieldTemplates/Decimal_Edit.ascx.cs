using System;
using System.Collections.Specialized;
using System.Web.UI;

namespace DBAdmin
{
    public partial class Decimal_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get
            {
                return TextBox1;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ToolTip = Column.Description;

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(CompareValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(RangeValidator1);
            SetUpValidator(DynamicValidator1);
        }
    }
}