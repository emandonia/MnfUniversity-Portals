using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class CommunicationViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetYouTubeUrl(string x)
        {
            return "https://www.youtube.com/channel/UCcoPxoor5XEnac34BwEI_9w";
            //string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            //if (abb != null) abb = abb.ToLower();
            //if (x == "ar")
            //{
            //    switch (abb)
            //    {
            //        case "fci":
            //            return "https://www.youtube.com/channel/UCfFmKc3AGVSdsOGPIEgC_lg";
            //            break;
            //        case "fee":
            //            return "http://www.youtube.com/channel/UCHyX0_F4MbDsbwXQ7SdAttA";
            //            break;
            //        case "liv":

            //            return "https://www.youtube.com/channel/UC1JRsj7pR05yDy0L4vEgvPw";
            //            break;
            //        case "eng":

            //            return "https://www.youtube.com/channel/UCv1OcoiN-qTQURF6AU9rdsA";
            //            break;
            //        case "agr":
            //            return "http://www.youtube.com/user/agrimenoufia";
            //            break;
            //        case "art":
            //            return "http://www.youtube.com/channel/UCz227cmlzNxcvLv-n8VhsMw?guided_help_flow=3&ytsession=yO7aptJrTr4bNEIPHwiqv99rzoPDLMbm328zLS30dtm4YSAAKvC6v3bgrhE5Tf77-02jhfAX4NmdOHBWRb07xkq7WVaUu6FOAgE0tDHNEWx-L5Qhhqw6yJt0su2ZNnXcIl2Tkw9Pdwvib_OZ18hGi9BW1qR9_i_C3tOOxYuqU-XrGCNjVoXA_SGuf56XY7GbwVvCRN5lzivKxo48EiI3cmFGPvxh7TmZTLEKnSIIER14I_BIlK7EI2YSWDkZI6Jj9_RbRHy5xR0eGqr5t-tnmYM6LcyuHkM1x4C5oWZez6IgmGLBfueNIJvAvLcWhs1Ot30R0o7o1pZJfogsYJV4dg";
            //            break;
            //        case "com":
            //            return "";
            //            break;
            //        case "edu":
            //            return "https://www.youtube.com/channel/UC_ZeBFYb18RppCyqA8uAZdQ";
            //            break;
            //        case "hec":
            //            return "http://www.youtube.com/user/MenofiaHomeEconomics";
            //            break;
            //        case "law":
            //            return " https://www.youtube.com/channel/UCzj9FnYczmbKJ_-ED0hxnMA";
            //            break;
            //        case "med":
            //            return "https://www.youtube.com/channel/UCBs3wQq8fpMLchAQPGVI0QQ/feed?view_as=public";
            //            break;
            //        case "nur":
            //            return "http://www.youtube.com/channel/UC7FgblZex7yuQw-_x6ZrE2g";
            //            break;
            //        case "sci":
            //            return " http://www.youtube.com/channel/UCP_9cM4zMkE-pO79APPSVtA/feed";
            //            break;
            //        case "edv":
            //            return "http://www.youtube.com/channel/UCGkELgfwH-4rwlioHG9cXSg";
            //            break;
            //        case "ho":
            //            return "";
            //            break;
            //        default:
            //            return "https://www.youtube.com/channel/UCfNjVPVBEGhj2YiUZGo-UuQ";
            //    }

            //}
            //else
            //{
            //    switch (abb)
            //    {
            //        case "fci":
            //            return "https://www.youtube.com/channel/UCfFmKc3AGVSdsOGPIEgC_lg";
            //            break;
            //        case "fee":
            //            return "http://www.youtube.com/channel/UCHyX0_F4MbDsbwXQ7SdAttA";
            //            break;
            //        case "liv":
            //            return "https://www.youtube.com/channel/UC1JRsj7pR05yDy0L4vEgvPw";
            //            break;
            //        case "eng":
            //            return "https://www.youtube.com/channel/UCv1OcoiN-qTQURF6AU9rdsA";
            //            break;
            //        case "agr":
            //            return "http://www.youtube.com/user/agrimenoufia";
            //            break;
            //        case "art":
            //            return "http://www.youtube.com/channel/UCz227cmlzNxcvLv-n8VhsMw?guided_help_flow=3&ytsession=yO7aptJrTr4bNEIPHwiqv99rzoPDLMbm328zLS30dtm4YSAAKvC6v3bgrhE5Tf77-02jhfAX4NmdOHBWRb07xkq7WVaUu6FOAgE0tDHNEWx-L5Qhhqw6yJt0su2ZNnXcIl2Tkw9Pdwvib_OZ18hGi9BW1qR9_i_C3tOOxYuqU-XrGCNjVoXA_SGuf56XY7GbwVvCRN5lzivKxo48EiI3cmFGPvxh7TmZTLEKnSIIER14I_BIlK7EI2YSWDkZI6Jj9_RbRHy5xR0eGqr5t-tnmYM6LcyuHkM1x4C5oWZez6IgmGLBfueNIJvAvLcWhs1Ot30R0o7o1pZJfogsYJV4dg";
            //            break;
            //        case "com":
            //            return "";
            //            break;
            //        case "edu":
            //            return "https://www.youtube.com/channel/UC_ZeBFYb18RppCyqA8uAZdQ";
            //            break;
            //        case "hec":
            //            return "http://www.youtube.com/user/MenofiaHomeEconomics";
            //            break;
            //        case "law":
            //            return " https://www.youtube.com/channel/UCzj9FnYczmbKJ_-ED0hxnMA";
            //            break;
            //        case "med":
            //            return "https://www.youtube.com/channel/UCBs3wQq8fpMLchAQPGVI0QQ/feed?view_as=public";
            //            break;
            //        case "nur":
            //            return "http://www.youtube.com/channel/UC7FgblZex7yuQw-_x6ZrE2g";
            //            break;
            //        case "sci":
            //            return " http://www.youtube.com/channel/UCP_9cM4zMkE-pO79APPSVtA/feed";
            //            break;
            //        case "edv":
            //            return "";
            //            break;
            //        case "ho":
            //            return "";
            //            break;
            //        default:
            //            return "https://www.youtube.com/channel/UCfNjVPVBEGhj2YiUZGo-UuQ";
            //    }

          //  }

        }

        public string GetFaceUl(string x)
        {
          
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if(abb ==null)
            { return "https://www.facebook.com/Media.MenoufiaUniversity/?fref=ts&__mref=message_bubble";


            }else if(abb.ToLower()=="med")
            {
                return "https://www.facebook.com/%D9%83%D9%84%D9%8A%D8%A9-%D8%A7%D9%84%D8%B7%D8%A8-%D8%AC%D8%A7%D9%85%D8%B9%D8%A9-%D8%A7%D9%84%D9%85%D9%86%D9%88%D9%81%D9%8A%D8%A9-%D8%A7%D9%84%D8%B5%D9%81%D8%AD%D8%A9-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9-206551722881167";
            }
          else  return "https://www.facebook.com/Media.MenoufiaUniversity/?fref=ts&__mref=message_bubble";

            //if (x == "ar")
            //{
            //    switch (abb)
            //    {
            //        case "fci":
            //            return "https://www.facebook.com/pages/Faculty-of-Computer-and-information-AR/544711865604435";
            //            break;
            //        case "fee":
            //            return "https://www.facebook.com/pages/Faculty-of-Electronic-Engineering-AR/484702644970018";
            //            break;
            //        case "liv":

            //            return "https://www.facebook.com/pages/National-Liver-Institute-AR/168939899980029";
            //            break;
            //        case "eng":

            //            return "https://www.facebook.com/pages/College-of-Engineering-AR/1396993707203262";
            //            break;
            //        case "agr":
            //            return "https://www.facebook.com/pages/Faculty-of-Agriculture-Ar/1415136288703948";
            //            break;
            //        case "art":
            //            return "https://www.facebook.com/pages/Faculty-of-Arts-AR/210034369169970";
            //            break;
            //        case "com":
            //            return "https://www.facebook.com/pages/Faculty-of-Commerce-AR/172709372931334";
            //            break;
            //        case "edu":
            //            return "https://www.facebook.com/pages/Faculty-of-Education-AR/455924747851880";
            //            break;
            //        case "hec":
            //            return "https://www.facebook.com/pages/Faculty-of-Home-Economics-AR/672350809451467";
            //            break;
            //        case "law":
            //            return "https://www.facebook.com/pages/Faculty-of-Law-AR/683611584984509";
            //            break;
            //        case "med":
            //            return "https://www.facebook.com/pages/Faculty-of-Medicine-AR/522652734489270";
            //            break;
            //        case "nur":
            //            return "https://www.facebook.com/pages/Faculty-of-Nursing-AR/693021430710175";
            //            break;
            //        case "sci":
            //            return "https://www.facebook.com/pages/Faculty-of-Science-AR/226699537499016";
            //            break;
            //        case "edv":
            //            return "https://www.facebook.com/pages/Faculty-of-Specific-Education-AR/192511060932432";
            //            break;
            //        case "ho":
            //            return "https://www.facebook.com/pages/University-Hospitals-AR/377890699007600";
            //            break;
            //        case "fa":
            //            return "https://www.facebook.com/faculty2015?fref=ts";
            //            break;
            //        default:
            //            return "https://www.facebook.com/pages/Menoufia-University-AR/383381225125142";
            //    }

            //}
            //else
            //{
            //    switch (abb)
            //    {
            //        case "fci":
            //            return "https://www.facebook.com/pages/Faculty-of-Computer-Informations-Menoufia-University/536877019721622";
            //            break;
            //        case "fee":
            //            return "https://www.facebook.com/pages/Faculty-of-Electronic-Engineering-Menoufia-University/252427431571589";
            //            break;
            //        case "liv":
            //            return "https://www.facebook.com/pages/National-Institute-of-Liver-Menoufia-University/168948776632329";
            //            break;
            //        case "eng":
            //            return "https://www.facebook.com/pages/Faculty-of-Engineering-Menoufia-University/604151972964686";
            //            break;
            //        case "agr":
            //            return "https://www.facebook.com/pages/Faculty-of-Agriculture-Menoufia-University/190486477805085";
            //            break;
            //        case "art":
            //            return "https://www.facebook.com/pages/Faculty-of-Arts-Menoufia-University/562167610499864";
            //            break;
            //        case "com":
            //            return "https://www.facebook.com/pages/Faculty-of-Commerce-Menoufia-University/191287224392034";
            //            break;
            //        case "edu":
            //            return "https://www.facebook.com/pages/Faculty-of-Education-Menoufia-University/647035068674514";
            //            break;
            //        case "hec":
            //            return "https://www.facebook.com/pages/Faculty-of-Home-Economy-Menoufia-University/168436800018090";
            //            break;
            //        case "law":
            //            return "https://www.facebook.com/pages/Faculty-of-Law-Menoufia-University/554546471284693";
            //            break;
            //        case "med":
            //            return "https://www.facebook.com/pages/Faculty-of-Medicine-Menoufia-University/363857187078506";
            //            break;
            //        case "nur":
            //            return "https://www.facebook.com/pages/Faculty-of-Nursing-Menoufia-University/200005350178682";
            //            break;
            //        case "sci":
            //            return "https://www.facebook.com/pages/Faculty-of-Science-Menoufia-University/526827600732073";
            //            break;
            //        case "edv":
            //            return "https://www.facebook.com/pages/Faculty-of-Specifie-Education-Menoufia-University/657974400910083";
            //            break;
            //        case "ho":
            //            return "https://www.facebook.com/pages/University-Hospitals-Menoufia-University/532535293493290";
            //            break;
            //        case "fa":
            //            return "https://www.facebook.com/faculty2015?fref=ts";
            //            break;
            //        default:
            //            return "https://www.facebook.com/pages/Menoufia-University- Page/1374780889427831";
            //    }

            // }

        }

        public string GetTwitterUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "https://twitter.com/fci_ar";

                    case "fee":
                        return "https://twitter.com/fee_ar";
                    case "liv":
                        return "https://twitter.com/Liver_Institute";
                    case "eng":
                        return "https://twitter.com/ar_engg";

                    case "agr":
                        return "https://twitter.com/mnfportal_agr";

                    case "art":
                        return "https://twitter.com/facartAr";
                    case "com":
                        return "https://twitter.com/Comm_ar";

                    case "edu":
                        return "https://twitter.com/ar_educ";

                    case "hec":
                        return "https://twitter.com/ar_hec";
                    case "law":
                        return "https://twitter.com/Mnfportal_law";
                    case "med":
                        return "https://twitter.com/ar_medc";
                    case "nur":
                        return "https://twitter.com/ar_nurs";
                    case "sci":
                        return "https://twitter.com/sci_ar";

                    case "edv":
                        return "https://twitter.com/edv_ar";

                    case "ho":
                        return "https://twitter.com/ar_hos";

                    default:
                        return "https://twitter.com/ar_uni";


                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "https://twitter.com/fci_en";

                    case "fee":
                        return "https://twitter.com/en_fee";
                    case "liv":
                        return "https://twitter.com/liv_en";
                    case "eng":
                        return "https://twitter.com/engg_en";

                    case "agr":
                        return "https://twitter.com/agr_en";

                    case "art":
                        return "https://twitter.com/facartEn";
                    case "com":
                        return "https://twitter.com/comm_en";

                    case "edu":
                        return "https://twitter.com/en_educ";

                    case "hec":
                        return "https://twitter.com/en_hec";
                    case "law":
                        return "https://twitter.com/law_en";
                    case "med":
                        return "https://twitter.com/en_medc";
                    case "nur":
                        return "https://twitter.com/en_nurs";
                    case "sci":
                        return "https://twitter.com/sci_en";

                    case "edv":
                        return "https://twitter.com/EnEdv";

                    case "ho":
                        return "https://twitter.com/en_hosp";

                    default:
                        return "https://twitter.com/en_uni";
                }

            }

        }

        public string GetBlogUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "http://fcimu.blogspot.com/p/blog-page.html";

                    case "fee":
                        return "http://feemu.blogspot.com/p/blog-page.html";
                    case "liv":
                        return "http://livmu.blogspot.com/p/blog-page.html";
                    case "eng":
                        return "http://engmu.blogspot.com/p/blog-page.html";

                    case "agr":
                        return "http://agrmu.blogspot.com/p/blog-page.html";

                    case "art":
                        return "http://artsmu.blogspot.com/p/blog-page.html";
                    case "com":
                        return "http://comm-mu.blogspot.com/p/blog-page.html";

                    case "edu":
                        return "http://mu-ed.blogspot.com/p/blog-page.html";

                    case "hec":
                        return "http://sedmu.blogspot.com/p/blog-page.html";
                    case "law":
                        return "http://lawmu.blogspot.com/p/blog-page.html";
                    case "med":
                        return "http://medmu.blogspot.com/p/blog-page.html";
                    case "nur":
                        return "http://nur-mu.blogspot.com/p/blog-page.html";
                    case "sci":
                        return "http://sci-mu.blogspot.com/p/blog-page.html";

                    case "edv":
                        return "http://edvmu.blogspot.com/p/blog-page.html";

                    case "ho":
                        return "http://hosmu.blogspot.com/p/blog-page.html";

                    default:
                        return "http://menf-univ.blogspot.com/p/blog-page_23.html";


                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "http://fcimu.blogspot.com/p/faculty-of-computers-and-information.html";

                    case "fee":
                        return "http://feemu.blogspot.com/p/faculty-of-electronic-engineering.html";
                    case "liv":
                        return "http://livmu.blogspot.com/p/liver-institute-news.html";
                    case "eng":
                        return "http://engmu.blogspot.com/p/faculty-of-engineering-news.html";

                    case "agr":
                        return "http://agrmu.blogspot.com/p/faculty-of-agriculture.html";

                    case "art":
                        return "http://artsmu.blogspot.com/p/faculty-of-arts.html";
                    case "com":
                        return "http://comm-mu.blogspot.com/p/faculty-of-commerce.html";

                    case "edu":
                        return "http://mu-ed.blogspot.com/p/faculty-of-education.html";

                    case "hec":
                        return "http://sedmu.blogspot.com/p/faculty-of-home-economy-news.html";
                    case "law":
                        return "http://lawmu.blogspot.com/p/faculty-of-law-news.html";
                    case "med":
                        return "http://medmu.blogspot.com/p/faculty-of-medicine-news.html";
                    case "nur":
                        return "http://nur-mu.blogspot.com/p/faculty-of-nursing-news.html";
                    case "sci":
                        return "http://sci-mu.blogspot.com/p/faculty-of-science-news.html";

                    case "edv":
                        return "http://edvmu.blogspot.com/p/faculty-of-specific-education-news.html";

                    case "ho":
                        return "http://hosmu.blogspot.com/p/hospitals-news.html";

                    default:
                        return "http://menf-univ.blogspot.com/p/menofia-university-news.html";
                }

            }

        }


        public string GetWordpressUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "https://mnffci.wordpress.com";

                    case "fee":
                        return "https://mnffee.wordpress.com";
                    case "liv":
                        return "http://mnfliver.wordpress.com/";
                    case "eng":
                        return "https://mnfportaleng.wordpress.com";

                    case "agr":
                        return "https://mnfagr.wordpress.com";

                    case "art":
                        return "https://mnfart.wordpress.com";
                    case "com":
                        return "https://mnfcom.wordpress.com";

                    case "edu":
                        return "https://mnfedu.wordpress.com";

                    case "hec":
                        return "https://mnfhec.wordpress.com";
                    case "law":
                        return "https://mnflaw.wordpress.com";
                    case "med":
                        return "https://mnfmed.wordpress.com";
                    case "nur":
                        return "https://mnfnur.wordpress.com";
                    case "sci":
                        return "https://mnfsci.wordpress.com";

                    case "edv":
                        return "https://mnfedv.wordpress.com";

                    case "ho":
                        return "https://mnfhos.wordpress.com";

                    default:
                        return "https://menofiauniversity.wordpress.com";


                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "http://mufcien.wordpress.com/";

                    case "fee":
                        return "http://mnffeeen.wordpress.com/";
                    case "liv":
                        return "http://mnfliveren.wordpress.com/";
                    case "eng":
                        return "http://mnfportaleng.wordpress.com/";

                    case "agr":
                        return "http://muagren.wordpress.com/";

                    case "art":
                        return "http://mnfarten.wordpress.com/";
                    case "com":
                        return "http://mnfcomen.wordpress.com/";

                    case "edu":
                        return "http://mueduen.wordpress.com/";

                    case "hec":
                        return "http://mnfhecen.wordpress.com/";
                    case "law":
                        return "http://mnflawen.wordpress.com/";
                    case "med":
                        return "http://mnfmeden.wordpress.com/";
                    case "nur":
                        return "http://mnfnuren.wordpress.com/";
                    case "sci":
                        return "http://mnfscien.wordpress.com/";

                    case "edv":
                        return "http://mnfedven.wordpress.com/";

                    case "ho":
                        return "http://mnfhosen.wordpress.com/";

                    default:
                        return "http://mnfportalsen.wordpress.com/";
                }

            }

        }


        public string GetTumblrUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "http://mufciar.tumblr.com";

                    case "fee":
                        return "http://mufeear.tumblr.com";
                    case "liv":
                        return "http://mulivar.tumblr.com";
                    case "eng":
                        return "http://muengar.tumblr.com";

                    case "agr":
                        return "http://muagrar.tumblr.com/";

                    case "art":
                        return "http://muartar.tumblr.com";
                    case "com":
                        return "http://mucomar.tumblr.com";

                    case "edu":
                        return "http://mueduar.tumblr.com";

                    case "hec":
                        return "http://muhecar.tumblr.com";
                    case "law":
                        return "http://mulawar.tumblr.com";
                    case "med":
                        return "http://mumedar.tumblr.com";
                    case "nur":
                        return "http://munurar.tumblr.com";
                    case "sci":
                        return "http://musciar.tumblr.com";

                    case "edv":
                        return "http://muedvar.tumblr.com";

                    case "ho":
                        return "http://muhosar.tumblr.com";

                    default:
                        return "http://mnfportal-us.tumblr.com";


                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "http://mufci.tumblr.com";

                    case "fee":
                        return "http://mufee0.tumblr.com";
                    case "liv":
                        return "";
                    case "eng":
                        return "http://mueng0.tumblr.com";

                    case "agr":
                        return "http://muagr.tumblr.com";

                    case "art":
                        return "http://muart0.tumblr.com";
                    case "com":
                        return "http://mucom0.tumblr.com";

                    case "edu":
                        return "http://muedu.tumblr.com";

                    case "hec":
                        return "http://Muhec0.tumblr.com";
                    case "law":
                        return "http://mulaw0.tumblr.com";
                    case "med":
                        return "http://Mumed0.tumblr.com";
                    case "nur":
                        return "http://munur0.tumblr.com";
                    case "sci":
                        return "http://musci0.tumblr.com";

                    case "edv":
                        return "http://muedv.tumblr.com";

                    case "ho":
                        return "http://muhos0.tumblr.com";

                    default:
                        return "http://menofia.tumblr.com";
                }

            }

        }


        public string GetWixUrl(string x)
        {
            string abb = URLBuilder.CurrentFacAbbr(Page.RouteData);
            if (abb != null) abb = abb.ToLower();
            if (x == "ar")
            {
                switch (abb)
                {
                    case "fci":
                        return "http://mnfportal.wix.com/fcim";

                    case "fee":
                        return "http://mnfportal.wix.com/mufee";
                    case "liv":
                        return "http://mnfportal.wix.com/muliv";
                    case "eng":
                        return "http://mnfportal.wix.com/mueng";

                    case "agr":
                        return "http://mnfportal.wix.com/fagr";

                    case "art":
                        return "http://mnfportal.wix.com/fart";
                    case "com":
                        return "http://mnfportal.wix.com/fcomm";

                    case "edu":
                        return "http://mnfportal.wix.com/fedu";

                    case "hec":
                        return "http://mnfportal.wix.com/fhec";
                    case "law":
                        return "http://mnfportal.wix.com/mulaw";
                    case "med":
                        return "http://mnfportal.wix.com/fmed";
                    case "nur":
                        return "http://mnfportal.wix.com/munur";
                    case "sci":
                        return "http://mnfportal.wix.com/musci";

                    case "edv":
                        return "http://mnfportal.wix.com/fedv";

                    case "ho":
                        return "http://mnfportal.wix.com/muhos";

                    default:
                        return "http://mnfportal.wix.com/mnfportal";


                }

            }
            else
            {
                switch (abb)
                {
                    case "fci":
                        return "http://mnfportal.wix.com/fcim#!fcinews/c19vo";

                    case "fee":
                        return "http://mnfportal.wix.com/mufee#!feeen/c1zh2";
                    case "liv":
                        return "http://mnfportal.wix.com/muliv#!liven/c1477";
                    case "eng":
                        return "http://mnfportal.wix.com/mueng#!enger/c1pil";

                    case "agr":
                        return "http://mnfportal.wix.com/fagr#!formmap/c24vq";

                    case "art":
                        return "http://mnfportal.wix.com/fart#!page2/cjg9";
                    case "com":
                        return "http://mnfportal.wix.com/fcomm#!page2/cjg9";

                    case "edu":
                        return "http://mnfportal.wix.com/fedu#!page2/cjg9";

                    case "hec":
                        return "http://mnfportal.wix.com/fhec#!page2/cjg9";
                    case "law":
                        return "http://mnfportal.wix.com/mulaw#!lawen/cxu0";
                    case "med":
                        return "http://mnfportal.wix.com/fmed#!page2/cjg9";
                    case "nur":
                        return "http://mnfportal.wix.com/munur#!nuren/c1lf5";
                    case "sci":
                        return "http://mnfportal.wix.com/musci#!scien/cumd";

                    case "edv":
                        return "http://mnfportal.wix.com/fedv#!page2/cjg9";

                    case "ho":
                        return "http://mnfportal.wix.com/muhos#!hosen/c1nmh";

                    default:
                        return "http://mnfportal.wix.com/mnfportal#!univ-en/cbtk";
                }

            }

        }
    }
}