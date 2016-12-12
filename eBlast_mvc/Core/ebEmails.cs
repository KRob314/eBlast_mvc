using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Web.Configuration;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Data.Entity.Validation;
using System.Web;
using System.Net.Mime;
using eBlast_mvc.Common;
using eBlast_mvc.Models;


namespace eBlast_mvc.Core
{
    public abstract class ebEmails
    {

        private MailMessage message = new MailMessage();
        private SmtpClient client = new SmtpClient();

        private string body = "";
        internal string _body = string.Empty;
        internal string _subject = string.Empty;
        internal string _UserName = string.Empty;
        internal string _FirstName = string.Empty;
        internal string _UserEmail = string.Empty;
        internal List<string> _emailAddresses;
        //internal string _EmailTemplate = string.Empty;
        //internal StreamReader _Reader = null;
        //internal WebRequest _WebRequest = null;
        //internal WebResponse _WebResponse = null;
        public string ReturnMsg { get; set; }

        public ebEmails()
        {
        }


        private void buildEmail()
        {
            message.IsBodyHtml = true;
            message.From = new MailAddress("email_address");
            message.Subject = this._subject;
            message.Body = this._body;

            foreach (var s in _emailAddresses)
            {
                message.Bcc.Add(s);
            }

            if (ebCommon.GetReleaseType() == "Prod")
            {
                client.Host = "localhost";
            }
            else
            {
                client.Host = "yourSever.com";
            }

            client.Port = 26;
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("email_address", "password");

        }

        protected internal void SendEmail()
        {
            buildEmail();

            try
            {
                client.Send(message);
                this.ReturnMsg = "";
            }
            catch (Exception ex)
            {
                //fcLog.InsertError(ex.Message, "AdminSendingEmail");
                this.ReturnMsg = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    this.ReturnMsg += " " + ex.InnerException.Message;
                }
            }

        }

    }


    public class Email : ebEmails
    {
        private Dictionary<string, string> customVariables;

        public Email(List<string>  EmailAddress, string subject, string body)
        {

            this._emailAddresses = EmailAddress;
            this._subject = HttpContext.Current.Server.HtmlEncode(subject);
            this._body = HtmlUtility.SanitizeHtml(body);

            SetUserInfo();

        }

        private void SetUserInfo()
        {
            if (customVariables != null)
            {
                foreach (KeyValuePair<string, string> item in customVariables)
                {
                    _body = _body.Replace(item.Key, HttpContext.Current.Server.HtmlEncode(item.Value));
                }
            }

            base.SendEmail();
        }

    }
}