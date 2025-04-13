using System;
using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_LoggingUtility
    {
        public static IEnumerable<prtl_Log_Action> GetActoinLogs(Guid? UserID)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                dc.DeferredLoadingEnabled = false;

                if (UserID != null)
                {
                    var username = dc.aspnet_Users.SingleOrDefault(y => y.UserId == UserID);
                    return dc.prtl_Log_Actions.Where(x => username != null && x.UserName == username.UserName);
                }
                return dc.prtl_Log_Actions;
            }
        }

        public static void InsertNewActionLog(string username, string op_desc, string op_table)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                dc.DeferredLoadingEnabled = false;
                var newLogging = new prtl_Log_Action
                {
                    UserName = username,
                    OperationDesc = op_desc,
                    OperationTable = op_table,
                    OperationDateTime = DateTime.Now
                };

                dc.prtl_Log_Actions.InsertOnSubmit(newLogging);
                dc.SubmitChanges();
            }
        }

        public static void InsertNewErrorLog(string username, string _exceptionMessage, string _innerExceptionMessage, string _exceptionStack, string _innerExceptionStack, string _pagePath)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                dc.DeferredLoadingEnabled = false;
                var newLogging = new Prtl_Log_Error
                {
                    UserName = username,
                    ExceptionMessage = _exceptionMessage,
                    InnerExceptionMessage = _innerExceptionMessage,
                    ExceptionStack = _exceptionStack,
                    InnerExceptionStack = _innerExceptionStack,
                    PagePath = _pagePath,
                    counter = 1,
                    Time = DateTime.Now
                };

                dc.Prtl_Log_Errors.InsertOnSubmit(newLogging);
                dc.SubmitChanges();
            }
        }

        public static bool CheckErrorInnerException(string innerexception)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                dc.DeferredLoadingEnabled = false;
                var result = dc.Prtl_Log_Errors.SingleOrDefault(x => x.InnerExceptionMessage == innerexception);
                return result != null;
            }
        }

        public static void UpdateExceptionCounter(string innerException, string page)
        {
            using (var dc = new PortalDataContextDataContext())
            {
                dc.DeferredLoadingEnabled = false;
                var result = dc.Prtl_Log_Errors.SingleOrDefault(x => x.InnerExceptionMessage == innerException);
                if (result != null)
                {
                    result.counter += 1;
                    result.PagePath = page;
                    result.Time = DateTime.Now;
                }
                dc.SubmitChanges();
            }
        }
    }
}