using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Yioulaieuwechat.Web.Models.ConiqModels;

namespace Yioulaieuwechat.Web.Help
{
    public class MailHelper
    {
        public static bool SendRegisterMail(fields model)
        {
            var username = ConfigurationManager.AppSettings["MailUser"];
            var pwd = ConfigurationManager.AppSettings["MailPWD"];
            var host = ConfigurationManager.AppSettings["Mailhost"];
            var json = JsonConvert.SerializeObject(model);
            //Convert.FromBase64String(token);解码
            var base64 = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(json));
            var url = "http://" + HttpContext.Current.Request.Url.Host + "/Home/VerifyEmail/" + "?code=" + base64;
            return SendMail(username, pwd, model.email, host, "Confirmation of registration", url, string.Empty);
        }
        public static bool SendMail(string userName, string pwd, string mailaddress, string host, string sub, string body, string filePath)
        {
            var client = new SmtpClient
            {
                Host = host,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(userName, pwd),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            try
            {
                var message = new MailMessage(userName, mailaddress)
                {
                    Subject = sub,
                    Body = body,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = true,
                };
                if (!string.IsNullOrEmpty(filePath))
                {
                    var attachment = new Attachment(filePath) { Name = filePath.Split('/').LastOrDefault() };
                    message.Attachments.Add(attachment);
                }
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}