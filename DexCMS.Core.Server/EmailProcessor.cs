using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.Core.Server
{
    public class EmailProcessor
    {
        public static string SmtpServer
        {
            get
            {
                return SiteSettings.Resolve.GetSetting("SmtpServer");
            }
        }

        public static string EmailFrom
        {
            get
            {
                return SiteSettings.Resolve.GetSetting("ContactFromEmail");
            }
        }

        public static string Password
        {
            get
            {
                return SiteSettings.Resolve.GetSetting("ContactFromPassword");
            }
        }

        public static string AdminEmails
        {
            get
            {
                return SiteSettings.Resolve.GetSetting("ContactTo");
            }
        }

        public static bool UseCredentials
        {
            get
            {
                return Convert.ToBoolean(SiteSettings.Resolve.GetSetting("ContactFromUseCredentials"));
            }
        }
        public static bool UsePort
        {
            get
            {
                return Convert.ToBoolean(SiteSettings.Resolve.GetSetting("ContactFromUsePort"));
            }
        }
        public static int ContactFromPort
        {
            get
            {
                return Convert.ToInt32(SiteSettings.Resolve.GetSetting("ContactFromPort"));
            }
        }

        /// <summary>
        /// for sending emails TO the clients from the admin.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static bool SendEmail(string message, string to, string subject)
        {

            bool success = false;
            EmailInfo emailInfo = new EmailInfo
            {
                EmailTo = to,
                ReplyTo = AdminEmails
            };


            MailMessage mail = new MailMessage();
            string emails = emailInfo.EmailTo;

            foreach (string email in emails.Split(','))
            {
                mail.To.Add(email);
            }

            mail.From = new MailAddress(EmailFrom);
            mail.ReplyToList.Add(emailInfo.ReplyTo);

            mail.Subject = subject;

            mail.Body = message;
            mail.IsBodyHtml = true;

            try
            {
                SendMail(mail);

                success = true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Email error occured. " + ex.Message);
            }
            return success;
        }//end SendEmail


        /// <summary>
        /// For sending emails to and from unique individuals.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static bool SendEmail(string message, string to, string from, string subject)
        {

            bool success = false;
            EmailInfo emailInfo = new EmailInfo
            {
                EmailTo = to,
                ReplyTo = from
            };


            MailMessage mail = new MailMessage();
            string emails = emailInfo.EmailTo;

            foreach (string email in emails.Split(','))
            {
                mail.To.Add(email);
            }

            mail.From = new MailAddress(EmailFrom);
            mail.ReplyToList.Add(emailInfo.ReplyTo);

            mail.Subject = subject;

            mail.Body = message;
            mail.IsBodyHtml = true;

            try
            {
                SendMail(mail);
                success = true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Email error occured. " + ex.Message);
            }
            return success;
        }//end SendEmail

        /// <summary>
        /// For sending emails to the Admins
        /// </summary>
        /// <param name="message"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool SendEmail(string message, string from, string subject, ModelStateDictionary model, string overrideTo = "")
        {
            //typically used for contact emails
            bool success = false;
            EmailInfo emailInfo = new EmailInfo
            {
                EmailTo = AdminEmails,
                ReplyTo = from
            };

            if (!string.IsNullOrEmpty(overrideTo))
            {
                emailInfo.EmailTo = overrideTo;
            }

            MailMessage mail = new MailMessage();
            string emails = emailInfo.EmailTo;

            foreach (string email in emails.Split(','))
            {
                mail.To.Add(email);
            }

            mail.From = new MailAddress(EmailFrom);
            mail.ReplyToList.Add(emailInfo.ReplyTo);

            mail.Subject = subject;

            mail.Body = message;
            mail.IsBodyHtml = true;

            try
            {
                SendMail(mail);
                success = true;
            }
            catch (Exception ex)
            {
                model.AddModelError("emailfailed", ex.Message);
            }
            return success;
        }//end SendEmail

        private static void SendMail(MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(SmtpServer);
            if (UseCredentials)
            {
                smtp.Credentials = new System.Net.NetworkCredential(EmailFrom, Password);
            }
            if (UsePort)
            {
                smtp.Port = ContactFromPort;
            }
            smtp.Send(mail);
        }

    }

    public enum EmailType
    {
        Contact,
        Account
    }

    public class EmailInfo
    {
        public string EmailTo { get; set; }
        public string ReplyTo { get; set; }
    }
}
