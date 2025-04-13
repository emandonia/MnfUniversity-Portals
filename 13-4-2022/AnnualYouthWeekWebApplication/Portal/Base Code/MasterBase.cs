using System.Web.UI;
using App_Code;
using Resources;

namespace MnfUniversity_Portals.Base_Code
{
    public class MasterBase : MasterPage
    {
        #region Properties

      
     
        #endregion Properties
      
    


       
        protected void ShowErrorMessage()
        {
            var lasterrormessage = PageBase.LastErrorMessage;
            if (!string.IsNullOrEmpty(lasterrormessage))
            {
                if (lasterrormessage == "Owner_Not_Exist")
                {
                    StaticUtilities.ShowErrorMessage(this, GlobalStrings.InvalidURL,
               GlobalStrings.Owner_Not_Exist);
                }
                else
                {
                    StaticUtilities.ShowErrorMessage(this, GlobalStrings.ErrorTitle,
                    GlobalStrings.DefaultError + "<br/>" + lasterrormessage);
                }
                PageBase.LastErrorMessage = "";
            }
        }
    }
}