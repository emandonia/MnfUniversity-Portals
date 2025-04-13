using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using App_Code;
using Common;
using MnfUniversity_Portals.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using App_Code;
using BLL;
using Common;
namespace MnfUniversity_Portals
{
    /// <summary>
    /// Summary description for RssService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RssService : System.Web.Services.WebService
    {

        [WebMethod]
        public string  getRssNews(int id,string x)
        {
            //HttpContext.Current.Response.Redirect (("http://mu.menofia.edu.eg/NewsRSS/ar"));

            switch (id)
            {
                case 1:
                    {
                        if (x == "ar")
                        {
                            return "http://mu.menofia.edu.eg/NewsRSS/ar";


                        }
                        else
                        {
                            return "http://mu.menofia.edu.eg/NewsRSS/en";
                        }
                        break;
                    }

                case 2:
                    {
                        if (x == "ar")
                        {
                            return "http://news.tanta.edu.eg/index.php?format=feed&type=rss&lang=ar";


                        }
                        else
                        {
                            return "http://news.tanta.edu.eg/index.php?format=feed&type=rss&lang=en";
                        }
                        break;
                    }
                case 3:
                    {
                        if (x == "ar")
                        {
                            return "http://cu.edu.eg/ar/rssNews/";


                        }
                        else
                        {
                            return "http://cu.edu.eg/rssNews/";
                        }
                        break;
                    }
                case 4:
                    {
                        if (x == "ar")
                        {
                            return "http://www.aswu.edu.eg/_layouts/feed.aspx?xsl=1&web=/Arabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=/Arabic/Pages/NewsRSSFeeds.aspx";


                        }
                        else
                        {
                            return "http://www.aswu.edu.eg/_layouts/feed.aspx?xsl=1&web=/English&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=/English/Pages/NewsRSSFeeds.aspx";
                        }
                        break;
                    }
                case 5:
                    {
                        if (x == "ar")
                        {
                            return "http://www.minia.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FArabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=%2FArabic%2FPages%2FNewsRSSFeeds%2Easpx";


                        }
                        else
                        {
                            return "http://www.minia.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FEnglish&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=%2FEnglish%2FPages%2FNewsRSSFeeds%2Easpx";
                        }
                        break;
                    }

                case 6:
                    {
                        if (x== "ar")
                        {
                            return "http://www.bu.edu.eg/Rss.xml";


                        }
                        else
                        {
                            return "http://www.bu.edu.eg/en/Rss.xml";
                        }
                        break;
                    }
                case 7:
                    {
                        if (x == "ar")
                        {
                            return "http://www.aun.edu.eg/arabic/rss_all.php";


                        }
                        else
                        {


                            return "http://www.aun.edu.eg/rss_all.php";
                        }
                        break;
                    }
                case 8:
                    {
                        if (x == "ar")
                        {
                            return "http://suezuniv.edu.eg/v2/index.php/uni-news?format=feed";


                        }
                        else
                        {


                            return "";
                        }
                        break;
                    }
                case 9:
                    {
                        if (x == "ar")
                        {
                            return "http://psu.edu.eg/all-news.feed?type=rss";


                        }
                        else
                        {


                            return "";
                        }
                        break;
                    }
                case 10:
                    {
                        if (x == "ar")
                        {
                            return "http://www.kfs.edu.eg/university/pdf/rss.xml";


                        }
                        else
                        {


                            return "http://www.kfs.edu.eg/engkfs/pdf/rss.xml";
                        }
                        break;
                    }
                case 11:
                    {
                        if (x == "ar")
                        {
                            return "http://portal.svu.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FArabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=%2FArabic%2FPages%2FNewsRSSFeeds.aspx";



                        }
                        else
                        {


                            return "http://portal.svu.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FEnglish&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=%2FEnglish%2FPages%2FNewsRSSFeeds.aspx";
                        }
                        break;
                    }
                

                case 12:
                    {
                        if (x == "ar")
                        {
                            return "http://www.mans.edu.eg/mans-news?format=feed&type=rss";



                        }
                        else
                        {


                            return "http://www.mans.edu.eg/en/mans-news?format=feed&type=rss";
                        }
                        break;
                    }

                case 13:
                    {
                        if (x == "ar")
                        {
                            return "http://www.sohag-univ.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FArabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=%2FArabic%2FPages%2FNewsRSSFeeds%2Easpx";



                        }
                        else
                        {


                            return "http://www.sohag-univ.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FEnglish&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=%2FEnglish%2FPages%2FNewsRSSFeeds%2Easpx";
                        }
                        break;
                    }
                case 14:
                    {
                        if (x == "ar")
                        {
                            return "http://www.usc.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FArabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=%2FArabic%2FPages%2FNewsRSSFeeds.aspx";



                        }
                        else
                        {


                            return "http://www.usc.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FEnglish&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=%2FEnglish%2FPages%2FNewsRSSFeeds%2Easpx";
                        }
                        break;
                    }
                case 15:
                    {
                        if (x == "ar")
                        {
                            return "http://www.news.zu.edu.eg/NewsRss.aspx?CatID=1";



                        }
                        else
                        {


                            return "http://www.news.zu.edu.eg/english/NewsRss.aspx?CatID=1";
                        }
                        break;
                    }
                case 16:
                    {
                        if (x == "ar")
                        {
                            return "http://www.du.edu.eg/du/rssAr.aspx";



                        }
                        else
                        {


                            return "";
                        }
                        break;
                    }
                case 17:
                    {
                        if (x == "ar")
                        {
                            return "http://www.fayoum.edu.eg/rss/";



                        }
                        else
                        {


                            return "http://www.fayoum.edu.eg/rss/";
                        }
                        break;
                    }

                case 18:
                    {
                        if (x == "ar")
                        {
                            return "http://www.asu.edu.eg/arabic/rss.php";



                        }
                        else
                        {


                            return "http://www.asu.edu.eg/rss.php/";
                        }
                        break;
                    }

                case 19:
                    {
                        if (x == "ar")
                        {
                            return "http://au.alexu.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FArabic&page=f6352b68-40b7-4d9a-b089-ffe9b05c36ae&wp=64b5929f-f754-460b-9dc2-6249b2f0ce33&pageurl=%2FArabic%2FPages%2FNewsRSSFeeds.aspx";



                        }
                        else
                        {


                            return "http://au.alexu.edu.eg/_layouts/feed.aspx?xsl=1&web=%2FEnglish&page=4c15cd20-e84c-4b7e-b942-e31352fc095e&wp=d5725327-35d2-46b0-b52d-aec37aa6ae7d&pageurl=%2FEnglish%2FPages%2FNewsRSSFeeds.aspx";
                        }
                        break;
                    }


                case 20:
                    {
                        if (x == "ar")
                        {
                            return "http://www.helwan.edu.eg/arabic/?feed=rss2";



                        }
                        else
                        {


                            return "http://www.helwan.edu.eg/English/?feed=rss2";
                        }
                        break;
                    }

                    case 21:
                    {
                        if (x == "ar")
                        {
                            return "http://damanhour.edu.eg/rss.xml";



                        }
                        else
                        {


                            return "http://damanhour.edu.eg/en/rss.xml";
                        }
                        break;
                    }


                     case 22:
                    {
                        if (x == "ar")
                        {
                            return "http://www.bsu.edu.eg/rss.aspx";



                        }
                        else
                        {


                            return "http://www.bsu.edu.eg/EnglishUniversityWebsite/rss.xml";
                        }
                        break;
                    }


                default:
                    return "http://mu.menofia.edu.eg/NewsRSS/ar";


            }

            
        }
    }
}
