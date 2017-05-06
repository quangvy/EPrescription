using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helper
{
    public static class GenericHelper
    {

        public static object GetNull(object objectValue)
        {
            if (objectValue == null)
            {
                return null;
            }

            Type objType = objectValue.GetType();
            if (objType == typeof(DateTime))
            {
                if (objectValue.Equals(DateTime.MinValue))
                    return null;
            }

            return objectValue;
        }

        public static void LogException(Exception ex, string requestFrom)
        {
            if ((!System.Diagnostics.EventLog.SourceExists(".NET Runtime")))
            {
                System.Diagnostics.EventLog.CreateEventSource(".NET Runtime", "Application");
            }

            dynamic log = new EventLog();
            log.Source = ".NET Runtime";
            log.WriteEntry(string.Format("\\r\\n\\r\\nApplication Error\\r\\n\\r\\n"
                + "MESSAGE: {0}\\r\\n"
                + "SOURCE: {1}\\r\\n"
                + "FORM: {2}\\r\\n"
                + "TARGETSITE: {4}\\r\\n"
                + "STACKTRACE: {5}\\r\\n",
                ex.Message, ex.Source, requestFrom, ex.TargetSite, ex.StackTrace), System.Diagnostics.EventLogEntryType.Error);
        }

        public static bool SendMail(string To, string Subject, string Body)
        {
            try
            {
                var myEmail = new System.Net.Mail.MailMessage();
                var fromMail = new System.Net.Mail.MailAddress("noreply@21stcentury.ca");
                myEmail.From = fromMail;

                foreach (string toemail in To.Split(','))
                {
                    myEmail.To.Add(toemail);
                }

                myEmail.IsBodyHtml = true;
                myEmail.Subject = Subject;

                myEmail.Body += "<html><body><font face='sans-serif' size='2'>";
                myEmail.Body += Body;
                myEmail.Body += "</font></body></html>";

                var client = new System.Net.Mail.SmtpClient();
                client.Send(myEmail);

            }
            catch (Exception ex)
            {
                LogException(ex, "Sent Email");
                return false;
            }
            return true;
        }

        public static string FormatUrl(string pageUrl, params string[] parameters)
        {
            if (parameters == null || parameters.Length <= 0)
            {
                return pageUrl;
            }

            string _url = pageUrl;
            foreach (string param in parameters)
            {
                if (!string.IsNullOrWhiteSpace(param))
                {
                    if (_url.Contains("?"))
                    {
                        _url = _url + "&" + param;
                    }
                    else
                    {
                        _url = _url + "?" + param;
                    }
                }
            }

            return _url;
        }
    }
}
