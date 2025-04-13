using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Management.Smo;

namespace AnnualYouthWeekWebApplication.BLL
{
    public static class HigherAdminsUtility
    {



        public static string GetpImagePath(object imagename)
        {
            if (imagename != null)
            {
                return "../Images/PersonalImages/" + imagename;
            }
            else
            {
                return "";
            }
        }
        public static string GetnImagePath(object imagename)
        {
            if (imagename != null)
            {
                return "../Images/NatIDImages/" + imagename;
            }
            else
            {
                return "";
            }
        }
        public static void insertHigherAdmin(string serial,string name, string nid, string bd, string bp, string phno, string address,
            string email, string pi, int admin_type,int university)
        {
            var dc = new  MyDataContext();
            Higher_Admin HA = new Higher_Admin
            {
                SerialNo = Convert.ToInt32(serial),
               Admin_Name = name,
               National_ID = nid,
               Birth_Date = bd,
               Birth_Place = bp,
               Phone_Number = phno,
               Address = address,
               Email = email,
               Personal_Image = pi,
               
               Admin_type_id = admin_type,
               University_id = university

            };

            dc.Higher_Admins.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }


      

        public static void UpdateHigherAdmin(int serial,int id, string nameText,string nidText, string toDateTime, string bpText, string phnoText, string addText, string emText, string piText, string typeid)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.Higher_Admins.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Admin_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.Phone_Number = phnoText;
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                
                hadmin.Admin_type_id = Convert.ToInt32(typeid);
                

                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc=new MyDataContext();
            var q = dc.Higher_Admins.SingleOrDefault(x => x.ID == id);
            dc.Higher_Admins.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().Higher_Admins.SingleOrDefault(x => x.ID == id).Personal_Image;
        }
        //public static string getNatidImage(int id)
        //{
        //    return new MyDataContext().Higher_Admins.SingleOrDefault(x => x.ID == id).NatID_Image;
        //}
        public static string  getadmintype(int id)
        {
            return new MyDataContext().Higher_Admins.SingleOrDefault(x => x.ID == id).Admin_type_id.ToString();
        }

        public static string getadmintype2(int toInt32)
        {
            return new MyDataContext().Higher_Admin_Types.SingleOrDefault(x => x.ID == toInt32).Admin_Type;
        }

        public static object GetadminByuniname(string uniname)
        {
            var dc=new MyDataContext();
            var q = from x in dc.Higher_Admins
                    where x.University.University_Name == uniname
                     select new
                     {
                         x.ID,
                         x.Admin_Name,
                         x.Birth_Date,
                         x.Birth_Place,
                         x.Address,
                         x.National_ID,
                         x.SerialNo,
                         x.Higher_Admin_Type.Admin_Type,
                         x.University.University_Name
                     };
            return q;
        }
        public static string GetcountadminByuniID(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Higher_Admins
                    where x.University_id == toInt32
                    select new
                    {
                        x.ID,
                        x.Admin_Name,
                        x.Birth_Date,
                        x.Birth_Place,
                        x.Address,
                        x.National_ID,
                        x.SerialNo,
                        x.Higher_Admin_Type.Admin_Type
                    };
            return q.Count().ToString();
        }

        public static object Getadmins()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Higher_Admins

                    select new
                    {
                        x.ID,
                        x.Admin_Name,
                        x.Birth_Date,
                        x.Birth_Place,
                        x.Address,
                        x.National_ID,
                        x.SerialNo,
                        x.Higher_Admin_Type.Admin_Type,
                        University_Name=x.University.University_Name
                    };
            return q;
        }
    }
}