using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class GeneralInstUtility
    {
        
        public static void insertGeneralInst(string serial,string name, string nid, string bd,bool gender, string bp, string phno, string address,
           string email, string pi, string ni, int admin_type, int university)
        {
            var dc = new MyDataContext();
            General_Instructor HA = new General_Instructor
            {
                SerialNo = Convert.ToInt32(serial),
                Gen_Inst_Name = name,
                National_ID = nid,
                Birth_Date = bd,
                Birth_Place = bp,
                Gender = gender,
                phone_no = phno,
                Address = address,
                Email = email,
                Personal_Image = pi,
                NatID_Image = ni,
                General_inst_type = admin_type,
                University_id = university

            };

            dc.General_Instructors.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }




        public static void UpdateHigherAdmin(int serial,int id, string nameText, string nidText, string toDateTime, string bpText,bool gender, string phnoText, string addText, string emText, string piText, string niText, string typeid)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.General_Instructors.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Gen_Inst_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.phone_no = phnoText;
                hadmin.Gender = gender;
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                hadmin.NatID_Image = niText;
                hadmin.General_inst_type = Convert.ToInt32(typeid);


                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc = new MyDataContext();
            var q = dc.General_Instructors.SingleOrDefault(x => x.ID == id);
            dc.General_Instructors.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().General_Instructors.SingleOrDefault(x => x.ID == id).Personal_Image;
        }
        public static string getNatidImage(int id)
        {
            return new MyDataContext().General_Instructors.SingleOrDefault(x => x.ID == id).NatID_Image;
        }
        public static string getadmintype(int id)
        {
            return new MyDataContext().General_Instructors.SingleOrDefault(x => x.ID == id).General_inst_type.ToString();
        }

        public static string getadmintype2(int toInt32)
        {
            return new MyDataContext().General_Instructor_Types.SingleOrDefault(x => x.ID == toInt32).Gen_Inst_Type;
        }


       

        public static bool getadmingender3(int toInt32)
        {
            var dc = new MyDataContext();
            bool xx = dc.General_Instructors.SingleOrDefault(x => x.ID == toInt32).Gender;
            return xx;
        }

        public static object GetinstByuniname(string uniname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.General_Instructors
                    where x.University.University_Name == uniname
                    select new
                    {
                        x.ID,
                        x.Gen_Inst_Name,
                        x.Birth_Place,
                        x.Address,
                       Gend= x.Gender1.gender1,
                       x.phone_no,
                        x.Birth_Date,
                        x.SerialNo,
                        x.General_Instructor_Type.Gen_Inst_Type,
                        x.National_ID,
                        x.University.University_Name
                        
                    };
            return q;
        }

        public static string GetcountinstByuniID(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.General_Instructors
                    where x.University_id == toInt32
                    select new
                    {
                        x.ID,
                        x.Gen_Inst_Name,
                        x.Birth_Place,
                        x.Address,
                        Gend = x.Gender1.gender1,
                        x.phone_no,
                        x.Birth_Date,
                        x.SerialNo,
                        x.General_Instructor_Type.Gen_Inst_Type,
                        x.National_ID,

                    };
            return q.Count().ToString();
        }

        public static object Getinsts()
        {
            var dc = new MyDataContext();
            var q = from x in dc.General_Instructors

                    select new
                    {
                        x.ID,
                        x.Gen_Inst_Name,
                        x.Birth_Place,
                       Gend= x.Gender1.gender1,
                       x.phone_no,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.General_Instructor_Type.Gen_Inst_Type,
                        x.National_ID,
                        x.University.University_Name

                    };
            return q;
        }
    }
}