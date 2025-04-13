using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class CompanionsUtilty
    {
        public static void insertGeneralInst(string serial,string name, string nid, string bd, bool gender, string bp, string phno, string address,
       string email, string pi, string ni, int admin_type, int university)
        {
            var dc = new MyDataContext();
            Companion HA = new Companion
            {
                SerialNo = Convert.ToInt32(serial),
                Comp_Name = name,
                National_ID = nid,
                Birth_Date = bd,
                Birth_Place = bp,
                Gender = gender,
                phone_no = phno,
                Address = address,
                Email = email,
                Personal_Image = pi,
                NatID_Image = ni,
                Comp_type = admin_type,
                University_id = university

            };

            dc.Companions.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }




        public static void UpdateHigherAdmin(int serial,int id, string nameText, string nidText, string toDateTime, string bpText, bool gender, string phnoText, string addText, string emText, string piText, string niText, string typeid)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.Companions.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Comp_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.phone_no = phnoText;
                hadmin.Gender = gender;
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                hadmin.NatID_Image = niText;
                hadmin.Comp_type = Convert.ToInt32(typeid);


                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc = new MyDataContext();
            var q = dc.Companions.SingleOrDefault(x => x.ID == id);
            dc.Companions.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().Companions.SingleOrDefault(x => x.ID == id).Personal_Image;
        }
        public static string getNatidImage(int id)
        {
            return new MyDataContext().Companions.SingleOrDefault(x => x.ID == id).NatID_Image;
        }
        public static string getadmintype(int id)
        {
            return new MyDataContext().Companions.SingleOrDefault(x => x.ID == id).Comp_type.ToString();
        }

        public static string getadmintype2(int toInt32)
        {
            return new MyDataContext().Companion_types.SingleOrDefault(x => x.ID == toInt32).Comp_Type;
        }




        public static bool getadmingender3(int toInt32)
        {
            var dc = new MyDataContext();
            bool xx = dc.Companions.SingleOrDefault(x => x.ID == toInt32).Gender;
            return xx;
        }

        public static object GetcompByUniName(string uniname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Companions
                    where x.University.University_Name == uniname
                    select new
                    {
                        x.ID,
                        x.Comp_Name,
                        x.Birth_Place,
                        x.Address,
                        x.phone_no,
                        Gend=x.Gender1.gender1,
                        x.Birth_Date,
                        x.SerialNo,
                        x.National_ID,
                        x.Companion_type.Comp_Type,
                        x.University.University_Name

                    };
            return q;
        }
        public static object Getcomps()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Companions
                    
                    select new
                    {
                        x.ID,
                        x.Comp_Name,
                        x.Birth_Place,
                        x.Address,
                        x.phone_no,
                        Gend = x.Gender1.gender1,
                        x.Birth_Date,
                        x.SerialNo,
                        x.National_ID,
                         x.Companion_type.Comp_Type,
                        x.University.University_Name

                    };
            return q;
        }
    }
}