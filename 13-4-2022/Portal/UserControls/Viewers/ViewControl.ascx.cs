using System.Web.UI;
using Common;
using MnfUniversity_Portals.UserControls.Base;


namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class ViewControl : UserControlBase
    {
        public string ArticleID
        {
            get
            {
                if (ViewerFormView.DataKey.Value != null)
                {
                    return ViewerFormView.DataKey.Value.ToString();
                }else
                {
                    return null;
                }
            }
        }

        [UrlProperty]
        public string UnderConstructionImageurl
        {
            get
            {
                return GetCommonWebResource("underconstruction");
            }
        }

        protected string BigImageURL(object imageName)
        {
            return URLBuilder.Path(Page, PathType.WebServer,
                              SiteFolders.Articles,
                             imageName ?? URLBuilder.DefaultImageName);
        }

        protected string SmallImageURL(object imageName)
        {
            return URLBuilder.Path(Page, PathType.WebServer,
                              SiteFolders.Articles_Thumb,
                             imageName ?? URLBuilder.DefaultImageName);
        }
    }
}