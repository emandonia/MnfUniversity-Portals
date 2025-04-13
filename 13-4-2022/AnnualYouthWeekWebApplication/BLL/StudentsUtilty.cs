using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Management.Smo;


namespace AnnualYouthWeekWebApplication.BLL
{
    public class StudentsUtilty
    {
        public static void insertGeneralInst(string serial,string name, string nid, string bd, bool gender, string bp, string phno,
            string address,
            string email, string pi, string ni, int facid, int yearid, int actid, int fieldid, int university)
        {
            var dc = new MyDataContext();
            Student HA = new Student
            {
                SerialNo = Convert.ToInt32(serial),
                Stu_Name = name,
                National_ID = nid,
                Birth_Date = bd,
                Birth_Place = bp,
                Gender = gender,
                phone_no = phno,
                Address = address,
                Email = email,
                Personal_Image = pi,
                NatID_Image = ni,
                Faculty_ID = facid,
                Year_ID = yearid,
                Activity_id = actid,
                Field_id = fieldid,
                University_id = university

            };

            dc.Students.InsertOnSubmit(HA);
            dc.SubmitChanges();


        }




        public static void UpdateHigherAdmin(int serial,int id, string nameText, string nidText, string toDateTime, string bpText,
            bool gender, string phnoText, string addText, string emText, string piText, string niText, int facid,
            int yearid, int actid, int fieldid)
        {
            var dc = new MyDataContext();
            {
                var hadmin = dc.Students.Single(a => a.ID == id);
                hadmin.SerialNo = serial;
                hadmin.Stu_Name = nameText;
                hadmin.National_ID = nidText;
                hadmin.Birth_Date = toDateTime;
                hadmin.Birth_Place = bpText;
                hadmin.phone_no = phnoText;
                hadmin.Gender = gender;
                hadmin.Address = addText;
                hadmin.Email = emText;
                hadmin.Personal_Image = piText;
                hadmin.NatID_Image = niText;
                hadmin.Faculty_ID = facid;
                hadmin.Year_ID = yearid;
                hadmin.Activity_id = actid;
                hadmin.Field_id = fieldid;


                dc.SubmitChanges();
            }
        }

        public static void DeleteAdmin(int id)
        {
            var dc = new MyDataContext();
            var q = dc.Students.SingleOrDefault(x => x.ID == id);
            dc.Students.DeleteOnSubmit(q);
            dc.SubmitChanges();
        }

        public static string getPersonalImage(int id)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == id).Personal_Image;
        }

        public static string getNatidImage(int id)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == id).NatID_Image;
        }

        //public static string getadmintype(int id)
        //{
        //    return new MyDataContext().st.SingleOrDefault(x => x.ID == id).Comp_type.ToString();
        //}

        //public static string getadmintype2(int toInt32)
        //{
        //    return new MyDataContext().Companion_types.SingleOrDefault(x => x.ID == toInt32).Comp_Type;
        //}




        public static bool getadmingender3(int toInt32)
        {
            var dc = new MyDataContext();
            bool xx = dc.Students.SingleOrDefault(x => x.ID == toInt32).Gender;
            return xx;
        }

        public static int getcurrentFacid(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Faculty_ID;
        }

        public static string getcurrentFac(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Faculty.Faculty1;
        }

        public static string getcurrentField(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Field.Field_Name;
        }

        public static int getcurrentFieldid(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Field_id;
        }

        public static string getcurrentact(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Field.Activity.Activity_Name;
        }

        public static int getcurrentactid(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Field.Activity.ID;
        }

        public static string getcurrentyear(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Year.Year1;
        }

        public static int getcurrentyearid(int toInt32)
        {
            return new MyDataContext().Students.SingleOrDefault(x => x.ID == toInt32).Year_ID;
        }

        public static string getfacfromfacid(int facid)
        {
            return new MyDataContext().Faculties.SingleOrDefault(x => x.ID == facid).Faculty1;
        }

        public static string getacfromacid(int toInt32)
        {
            return new MyDataContext().Activities.SingleOrDefault(x => x.ID == toInt32).Activity_Name;
        }

        public static int getfacidfromfac(int facid)
        {
            return new MyDataContext().Faculties.SingleOrDefault(x => x.ID == facid).ID;
        }

        //public static int getacidfromac(int acid)
        //{
        //    return new MyDataContext().Activities.SingleOrDefault(x => x.ID == acid).ID;
        //}
        public static object GetStudentByName(string textBox1Text)
        {
            var dc = new MyDataContext();
            var q = (from x in dc.Students
                where x.Stu_Name == textBox1Text
                select new
                {
                    SerialNo = x.SerialNo,
                    Stu_Name = x.Stu_Name,
                    University_Name = x.University.University_Name,
                    Activity_Name = x.Field.Activity.Activity_Name,
                    Field_Name = x.Field.Field_Name
                });
            return q;
        }

        public static string GetStudentPIByName(string textBox1Text)
        {
            var dc = new MyDataContext();
            return "~/Images/PersonalImages/" +
                   dc.Students.SingleOrDefault(x => x.Stu_Name == textBox1Text).Personal_Image;
        }

        public static object GetStudentByUniName(string name)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students
                where x.University.University_Name == name
                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,
                       Faculty= x.Faculty.Faculty1,
                       Year= x.Year.Year1,
                       x.University.University_Name

                    };
            return q;
        }
        public static object GetStudentByactiId(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students
                    where x.Activity_id == toInt32
                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,
                        Faculty = x.Faculty.Faculty1,
                        Year = x.Year.Year1

                    };
            return q;
        }
        public static string GetcountStudentByUniId(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students
                    where x.University_id == toInt32
                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,

                    };
            return q.Count().ToString();
        }
        public static object GetStudents()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students

                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,
                        Faculty = x.Faculty.Faculty1,
                        Year = x.Year.Year1,
                        x.University.University_Name

                    };
            return q;
        }


        public static object GetStudentByByActnameanduniname(string uniname, string actname)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students
                    where x.University.University_Name==uniname && x.Field.Field_Name==actname
                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,
                        Faculty = x.Faculty.Faculty1,
                        Year = x.Year.Year1,
                        x.University.University_Name

                    };
            return q;
        }

        public static object GetStudentByByFieldnameanduniname(string uniname, string fieldName)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Students
                    where x.University.University_Name == uniname && x.Field.Field_Name == fieldName
                    select new
                    {
                        x.ID,
                        x.Stu_Name,
                        x.Birth_Place,
                        x.Address,
                        x.Birth_Date,
                        x.SerialNo,
                        x.Field.Activity.Activity_Name,
                        x.Field.Field_Name,
                        x.National_ID,
                        Faculty = x.Faculty.Faculty1,
                        Year = x.Year.Year1,
                        x.University.University_Name

                    };
            return q;
        }
    }
}