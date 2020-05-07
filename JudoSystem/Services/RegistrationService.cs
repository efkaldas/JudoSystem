using Entities.Models;
using JudoSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class RegistrationService
    {
        private string userMessageEN = "<p>Hello,</p>" +
                    "<p>you have successfully pushed registration form!</p>" +
                    "<p>Now you need to wait till administrators review your account.</p>" +
                    "<p>Administrators will send email when your account status will change.</p></br>";

        private string userMessageLT = "<p>Sveiki,</p>" +
                    "<p>jus sėkmingai pateikėte registracijos formą!</p>" +
                    "<p>Dabar administratoriai peržiūrės ją ir patvirtins arba atmes jūsų registraciją.</p></br>" +
                    "<p>Administratoriai informuos jus žinute.</p>";

        private string userMessageRU = "<p> Здравствуйте, </p>" +
                    "<p> Вы успешно отправили регистрационную форму! </p>" +
                    "<p> Теперь вам нужно подождать, пока администраторы просмотрят вашу учетную запись. </p>" +
                    "<p> Администраторы отправят электронное письмо, когда состояние вашей учетной записи изменится. </p></br>";
        public void SendMessage(User user)
        {
            SendUserMessage(user);
        }
        public void SendUserMessage(User user)
        {
            EmailSendHelper sendMail = new EmailSendHelper();
            if (!string.IsNullOrEmpty(user.Email))
            {
                string message = userMessageLT + userMessageEN + userMessageRU;

                List<string> recipients = new List<string>();
                recipients.Add(user.Email);

                sendMail.sendEmail(DateTime.Now.ToString("yyyy-MM-dd") + "Registracijos forma sėkmingai pateikta!", message, null, recipients);
            }
        }
        //public void SendAdministratorMessage(User user)
        //{
        //    EmailSendHelper sendMail = new EmailSendHelper();
        //    if (!string.IsNullOrEmpty(user.Email))
        //    {
        //        string message = userMessageLT + userMessageEN + userMessageRU;

        //        List<string> recipients = new List<string>();
        //        recipients.Add(user.Email);

        //        sendMail.sendEmail(DateTime.Now.ToString("yyyy-MM-dd") + "Registracijos forma sėkmingai pateikta!", message, null, recipients);
        //    }
        //}
    }
}
