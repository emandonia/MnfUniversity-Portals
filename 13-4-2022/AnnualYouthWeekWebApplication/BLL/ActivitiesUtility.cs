using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class ActivitiesUtility
    {


        public static object GetActByActiId(int toInt32)
        {
            var dc = new MyDataContext();
            var q = from x in dc.Fields
                    where x.Activity_id == toInt32
                    select new
                    {
                        x.ID,
                       x.Field_Name,
                       x.Activity.Activity_Name

                    };
            return q;
        }
        public static object GetAct()
        {
            var dc = new MyDataContext();
            var q = from x in dc.Fields
                    
                    select new
                    {
                        x.ID,
                        x.Field_Name,
                        x.Activity.Activity_Name,
                        

                    };
            return q;
        }
    }
}