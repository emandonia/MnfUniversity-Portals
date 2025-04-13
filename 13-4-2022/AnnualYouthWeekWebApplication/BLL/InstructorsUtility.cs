using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class InstructorsUtility
    {
        public static void insertGeneralInst(string serial,string name, string nid, string bd, bool gender, string bp, string phno, string address,
          string email, string pi, string ni, int admin_type, int university,int fieldid)
        {
            var dc = new MyDataContext();
            Instructor HA = new Instructor
            {
                SerialNo = Convert.ToInt32(serial),
                Inst_Name = name,
                National_ID = nid,
                Birth_Date = bd,
                Birth_Place = bp,
                Gender = gender,
                phone_no = phno,
                Address = address,
                Email = email,
                Personal_Image = pi,
                NatID_Image = ni,
                Inst_type = admin_type,
                University_id = university,
                FieldID = fieldid

            };

            dc.Instructors.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }




        public static void UpdateHigherAdmin(int serial,int id, string nameText, string nidText, string toDateTime, string bpText, bool gender, string phnoText, string addText, string emText, string piText, string niText, string typeid,int fieldid)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.Instructors.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Inst_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.phone_no = phnoText;
                hadmin.Gender = gender;
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                hadmin.NatID_Image = niText;
                hadmin.Inst_type = Convert.ToInt32(typeid);
                hadmin.FieldID = fieldid;


                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc = new MyDataContext();
            var q = dc.Instructors.SingleOrDefault(x => x.ID == id);
            dc.Instructors.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().Instructors.SingleOrDefault(x => x.ID == id).Personal_Image;
        }
        public static string getNatidImage(int id)
        {
            return new MyDataContext().Instructors.SingleOrDefault(x => x.ID == id).NatID_Image;
        }
        public static string getadmintype(int id)
        {
            return new MyDataContext().Instructors.SingleOrDefault(x => x.ID == id).Inst_type.ToString();
        }
        public static string getfield(int id)
        {
            return new MyDataContext().Instructors.SingleOrDefault(x => x.ID == id).FieldID.ToString();
        }

        public static string getadmintype2(int toInt32)
        {
            return new MyDataContext().Instructor_Types.SingleOrDefault(x => x.ID == toInt32).Inst_Type;
        }

        public static IEnumerable<Instructor> getInstByUniID(int uniid)
        {
            return
                new MyDataContext().Instructors.OrderByDescending(x => x.Inst_Name)
                    .Where(xx => xx.University_id == uniid);
        }


        public static bool getadmingender3(int toInt32)
        {
            var dc = new MyDataContext();
            bool xx = dc.Instructors.SingleOrDefault(x => x.ID == toInt32).Gender;
            return xx;
        }

        public static string GetInsField(int toInt32)
        {
            return new MyDataContext().Fields.SingleOrDefault(x => x.ID == toInt32).Field_Name;
        }

        public static object GetinstByuniName(string name)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                    where x.University.University_Name == name
                    select new
                    {
                        x.ID,
                        x.Inst_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.phone_no,
                        Gend=x.Gender1.gender1,
                        x.SerialNo,
                       Expr1= x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.University.University_Name,
                        x.Field.Activity.Activity_Name

                    };
            return q;
        }
        public static string GetcountinstByuniID(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                    where x.University_id == toInt32
                    select new
                    {
                        x.ID,
                        x.Inst_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.phone_no,
                        x.SerialNo,
                        Gend = x.Gender1.gender1,
                        Expr1 = x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.Field.Activity.Activity_Name

                    };
            return q.Count().ToString();
        }
        public static object Getinsts()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors

                    select new
                    {
                        x.ID,
                        x.Inst_Name,
                        x.Birth_Place,
                        x.Address,
                        Gend = x.Gender1.gender1,
                        x.phone_no,
                        x.Birth_Date,
                        x.SerialNo,
                        Expr1=x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.University.University_Name,
                        x.Field.Activity.Activity_Name

                    };
            return q;
        }

        public static object getInstByActnameanduniname(string actname,string uniname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                    where x.Field.Activity.Activity_Name==actname && x.University.University_Name==uniname
                    select new
                    {
                        x.ID,
                        x.Inst_Name,
                       
                        Expr1 = x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x. Field.Activity.Activity_Name,
                        x.University.University_Name
                       

                    };
            return q;
        }

        public static object getInst()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                   
                    select new
                    {
                        x.ID,
                        x.Inst_Name,

                        Expr1 = x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.Field.Activity.Activity_Name,
                        x.University.University_Name

                    };
            return q;
        }

        public static object GetinstByActName(string Actname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                    where x.Field.Activity.Activity_Name == Actname
                    select new
                    {
                        x.ID,
                        x.Inst_Name,

                        Expr1 = x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.Field.Activity.Activity_Name,
                        x.University.University_Name

                    };
            return q;
        }
    }
}