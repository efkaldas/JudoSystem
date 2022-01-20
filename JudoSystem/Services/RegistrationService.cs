﻿using Entities.Models;
using JudoSystem.Helpers;
using JudoSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEmailSendService _emailSendService;
        public RegistrationService(IEmailSendService emailSendService)
        {
            _emailSendService = emailSendService;
        }
        private string userMessageEN = "<p>Hello,</p>" +
                    "<p>you have successfully pushed registration form!</p>" +
                    "<p>Now you need to wait till administrators review your account.</p>" +
                    "<p>Administrators will send email when your account status will change.</p>" +
                    "<p>==========================================================================</p>";

        private string userMessageLT = "<p>Sveiki,</p>" +
                    "<p>jus sėkmingai pateikėte registracijos formą!</p>" +
                    "<p>Dabar administratoriai peržiūrės ją ir patvirtins arba atmes jūsų registraciją.</p>" +
                    "<p>Administratoriai informuos jus žinute.</p>" +
                    "<p>==========================================================================</p>";

        private string userMessageRU = "<p> Здравствуйте, </p>" +
                    "<p> Вы успешно отправили регистрационную форму! </p>" +
                    "<p> Теперь вам нужно подождать, пока администраторы просмотрят вашу учетную запись. </p>" +
                    "<p> Администраторы отправят электронное письмо, когда состояние вашей учетной записи изменится. </p>"+
                    "<p>==========================================================================</p>";
        public void SendMessage(User user)
        {
            SendUserMessage(user);
            SendAdministratorMessage(user);
        }
        private void SendUserMessage(User user)
        {
            if (!string.IsNullOrEmpty(user.Email))
            {
                string message = userMessageLT + userMessageEN + userMessageRU;

                List<string> recipients = new List<string>();
                recipients.Add(user.Email);

                _emailSendService.SendEmail(DateTime.Now.ToString("yyyy-MM-dd") + " Registracijos forma sėkmingai pateikta!", message, recipients);
            }
        }
        private void SendAdministratorMessage(User user)
        {
            string message = "<p>Buvo pateikta nauja registacijos forma</p>";

            List<string> recipients = new List<string>();
            recipients.Add(_emailSendService.GetAdminEmail());

            _emailSendService.SendEmail(DateTime.Now.ToString("yyyy-MM-dd") + " Pateikta nauja registracijos forma!", message, recipients);
        }
    }
}
