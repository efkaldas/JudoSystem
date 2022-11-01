using JudoSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class EmailSendService : IEmailSendService
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        bool process;
        int repeat;
        TimeSpan time = new TimeSpan(0, 0, 1, 0);
        public readonly string ADMIN_LOGIN = "judosystem.info@gmail.com";
        public readonly string ADMIN_PASSWORD = "diyqfcxphezqppzy";
        public readonly string ADMIN_PASSWORD2 = "gq9ECcs9ZCg7QaxE";

        public void SendEmail(string title, string message, List<string> recipients, string fileToAttach = null)
        {
            process = true;
            repeat = 0;

            while (process && repeat < 5)
            {
                try
                {
                    msg = new MailMessage { From = new MailAddress(ADMIN_LOGIN, "Judo System Admin", Encoding.UTF8) };

                    foreach (string recipient in recipients)
                        msg.To.Add(new MailAddress(recipient));

                    msg.Subject = title;
                    msg.Body = message;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.Normal;

                    if (!string.IsNullOrEmpty(fileToAttach))
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(fileToAttach);
                        msg.Attachments.Add(attachment);
                    }

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(ADMIN_LOGIN, ADMIN_PASSWORD);
                        smtp.Send(msg);
                    }
                    process = false;
                }
                catch (Exception e)
                {
                    repeat++;
                    Thread.Sleep(time);
                }
            }
        }
        public string GetAdminEmail()
        {
            return ADMIN_LOGIN;
        }
    }
}
