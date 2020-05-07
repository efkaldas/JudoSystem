using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JudoSystem.Helpers
{
    public class EmailSendHelper
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        bool process;
        int repeat;
        TimeSpan time = new TimeSpan(0, 0, 1, 0);
        public static readonly string ADMIN_LOGIN = "judosystem.info@gmail.com";
        public static readonly string ADMIN_PASSWORD = "adminJudo1337";

        public void sendEmail(string title, string message, string fileToAttach, List<string> recipients)
        {
            process = true;
            repeat = 0;

            while (process && repeat < 5)
            {

                try
                {
                    login = new NetworkCredential(ADMIN_LOGIN, ADMIN_PASSWORD);
                    client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = login;
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

                    client.Send(msg);
                    process = false;
                }
                catch (Exception e)
                {
                    repeat++;
                    Thread.Sleep(time);
                }
            }
        }
    }
}
