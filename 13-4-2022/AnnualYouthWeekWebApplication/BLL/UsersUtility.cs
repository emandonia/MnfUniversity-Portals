using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;
//using BrandonHaynes.ModelAdapter;

namespace AnnualYouthWeekWebApplication.BLL
{
    public static class UsersUtility
    {
               public static User getuser(string username,string password)
        {
           // var dc = new DotNetNukeDataContext(connection, mappingSource);
            return new MyDataContext().Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
               //public static User getuser2( string password)
               //{
               //    // var dc = new DotNetNukeDataContext(connection, mappingSource);
               //    return new MyDataContext().Users.SingleOrDefault(x => x.Password == password);
               //}

        public static void resetpassword(string username,string pass)
        {
            var dc = new MyDataContext();
            {
                User x = dc.Users.SingleOrDefault(xx => xx.UserName == username);
                x.Password = pass;
                dc.SubmitChanges();
            }
        }
        public static void updateloginstate(int id,bool state)
        {var dc = new MyDataContext();
            {
                User x = dc.Users.SingleOrDefault(xx => xx.ID == id);
                x.Loginstate = state;
                dc.SubmitChanges();
            }
        }
        public static void updatepassword(int id, string newpass)
        {
            var dc = new MyDataContext();
            {
                User x = dc.Users.SingleOrDefault(xx => xx.ID == id);
                x.Password=newpass;
                dc.SubmitChanges();
            }
        } 
        public static bool checkuserIfExists(string username)
        {
            return new MyDataContext().Users.Any(x => x.UserName == username );
        }
        public static bool checkPass(string Pass)
        {
            return new MyDataContext().Users.Any(x => x.Password==Pass);
        }
        public static User GetUniFromUser(string username)
        {
            return new MyDataContext().Users.SingleOrDefault(x=>x.UserName==username);
        }

    }
}