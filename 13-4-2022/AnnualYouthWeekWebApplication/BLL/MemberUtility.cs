using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class MemberUtility
    {



        public static void insertMember(string serial, string name, string nid, string bd, string bp, string phno, string address,
         string email, string pi, string ni, int university)
        {
            var dc = new MyDataContext();
            Member HA = new Member
            {
                SerialNo = Convert.ToInt32(serial),
                Member_Name = name,
                National_ID = nid,
                Birth_Date = bd,
                Birth_Place = bp,
                
                phone_no = phno,
                Address = address,
                Email = email,
                Personal_Image = pi,
                NatID_Image = ni,
                
                University_id = university
                

            };

            dc.Members.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }




        public static void UpdateMember(int serial, int id, string nameText, string nidText, string toDateTime, string bpText, string phnoText, string addText, string emText, string piText, string niText)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.Members.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Member_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.phone_no = phnoText;
               
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                hadmin.NatID_Image = niText;
             
                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc = new MyDataContext();
            var q = dc.Members.SingleOrDefault(x => x.ID == id);
            dc.Members.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().Members.SingleOrDefault(x => x.ID == id).Personal_Image;
        }
        public static string getNatidImage(int id)
        {
            return new MyDataContext().Members.SingleOrDefault(x => x.ID == id).NatID_Image;
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
                        x.SerialNo,
                        Expr1 = x.Instructor_Type.Inst_Type,
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
                        x.SerialNo,
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
                        x.Birth_Date,
                        x.SerialNo,
                        Expr1 = x.Instructor_Type.Inst_Type,
                        x.Field.Field_Name,
                        x.National_ID,
                        x.University.University_Name,
                        x.Field.Activity.Activity_Name

                    };
            return q;
        }

        public static object getInstByActnameanduniname(string actname, string uniname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Instructors
                    where x.Field.Activity.Activity_Name == actname && x.University.University_Name == uniname
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