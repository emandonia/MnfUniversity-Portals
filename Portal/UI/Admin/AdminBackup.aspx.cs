using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using Common;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Table = Microsoft.SqlServer.Management.Smo.Table;


namespace MnfUniversity_Portals.UI
{
    public partial class AdminBackup : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public  object GetFacultiesMenuBackup(string facName)
        {
            string s = URLBuilder.PhysicalPath("") + "LocalBackup\\" + facName+"\\Menu";
            var q =
                (from x in
                     Directory.GetFiles(s)
                    select new {FileName = x.Substring(x.LastIndexOf("\\")+1),
                                url = "http://" + Request.Url.Authority + "/PrtlFiles/LocalBackup/" + facName + "/Menu/" + x.Substring(x.LastIndexOf("\\")+1)
                    });
            return q;
        }
        public object GetFacultiesNewsBackup(string facName)
        {
            string s = URLBuilder.PhysicalPath("") + "LocalBackup\\" + facName + "\\News";
            var q =
                (from x in
                     Directory.GetFiles(s)
                 select new
                 {
                     FileName = x.Substring(x.LastIndexOf("\\") + 1),
                     url = "http://" + Request.Url.Authority + "/PrtlFiles/LocalBackup/" + facName + "/News/" + x.Substring(x.LastIndexOf("\\") + 1)
                 });
            return q;
        }
        public string ScriptMenuTables(string facname)
        {
            var sb = new StringBuilder();

            var server = new Server(new ServerConnection(@"172.16.1.22\SQLSERVER", "portal_admin", "P0rt@lAdm!n"));
            var databse = server.Databases["MnfPortals"];
            
            var scripter = new Scripter(server);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = false;
            scripter.Options.IncludeHeaders = true;
            scripter.Options.ScriptData = true;
            //And so on ....
           
            var smoObjects = new Urn[1];
            foreach (Table t in databse.Tables)
            {
                if (t.Name == "prtl_menu_" + facname)
                {
                    smoObjects[0] = t.Urn;
                    if (t.IsSystemObject == false)
                    {
                        var sc = scripter.EnumScript(smoObjects);

                        foreach (var st in sc)
                        {
                            sb.Append(st);
                        }
                    }
                }
            }
            var smoObjects2 = new Urn[1];
            foreach (Table t in databse.Tables)
            {
                if (t.Name == "prtl_menu_" + facname + "_trans")
                {
                    smoObjects2[0] = t.Urn;
                    if (t.IsSystemObject == false)
                    {
                        var sc = scripter.EnumScript(smoObjects2);

                        foreach (var st in sc)
                        {
                            sb.Append(st);
                        }
                    }
                }
            }
            return sb.ToString();
        }
        public string ScriptNewsTables(string facname)
        {
            var sb = new StringBuilder();

            var server = new Server(new ServerConnection(@"172.16.1.22\SQLSERVER", "portal_admin", "P0rt@lAdm!n"));
            var databse = server.Databases["MnfPortals"];

            var scripter = new Scripter(server);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = false;
            scripter.Options.IncludeHeaders = true;
            scripter.Options.ScriptData = true;
            //And so on ....

            var smoObjects = new Urn[1];
            foreach (Table t in databse.Tables)
            {
                if (t.Name == "prtl_news_" + facname)
                {
                    smoObjects[0] = t.Urn;
                    if (t.IsSystemObject == false)
                    {
                        var sc = scripter.EnumScript(smoObjects);

                        foreach (var st in sc)
                        {
                            sb.Append(st);
                        }
                    }
                }
            }
            var smoObjects2 = new Urn[1];
            foreach (Table t in databse.Tables)
            {
                if (t.Name == "prtl_news_" + facname + "_trans")
                {
                    smoObjects2[0] = t.Urn;
                    if (t.IsSystemObject == false)
                    {
                        var sc = scripter.EnumScript(smoObjects2);

                        foreach (var st in sc)
                        {
                            sb.Append(st);
                        }
                    }
                }
            }
            return sb.ToString();
        }
       
        protected void Button1_OnClick(object sender, EventArgs e)
        {
           
                LinkButton1.Visible = true;
                LinkButton2.Visible = true;
               ListView1.DataSource= GetFacultiesMenuBackup(DropDownList1.SelectedValue);
                ListView1.DataBind();
                ListView2.DataSource = GetFacultiesNewsBackup(DropDownList1.SelectedValue);
                ListView2.DataBind();
           
        }

        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            string str_uploadpath = URLBuilder.PhysicalPath("") + "LocalBackup\\" +
                                    DropDownList1.SelectedValue + "\\Menu\\";
            string file = DropDownList1.SelectedValue + "_menu_bak" + DateTime.Now.Date.ToString("dd-MM-yyyy",ci) + ".sql";
            string filename = Path.Combine(str_uploadpath, file);
            
            System.IO.File.WriteAllText(filename, ScriptMenuTables(DropDownList1.SelectedValue));
            ListView1.DataSource = GetFacultiesMenuBackup(DropDownList1.SelectedValue);
            ListView1.DataBind();
        }

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            string str_uploadpath = URLBuilder.PhysicalPath("") + "LocalBackup\\" +
                                   DropDownList1.SelectedValue + "\\News\\";
            string file = DropDownList1.SelectedValue + "_news_bak" + DateTime.Now.Date.ToString("dd-MM-yyyy",ci) + ".sql";
            string filename = Path.Combine(str_uploadpath, file);
            System.IO.File.WriteAllText(filename, ScriptNewsTables(DropDownList1.SelectedValue));
            ListView2.DataSource = GetFacultiesNewsBackup(DropDownList1.SelectedValue);
            ListView2.DataBind();
           
        }
    }
}