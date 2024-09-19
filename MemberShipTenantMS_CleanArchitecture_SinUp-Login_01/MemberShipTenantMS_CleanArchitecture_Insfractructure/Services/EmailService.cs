////using NETCore.MailKit.Core;
//using System;
//using System.Collections.Generic;
//using System.Linq;
////using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;
//using MailKit.Net.Smtp;
//using MemberShipTenantMS_CleanArchitecture_Application.Services;
//using MemberShipTenantMS_CleanArchitecture_Application.Services.Models;
//using Microsoft.EntityFrameworkCore.Query.Internal;
//using MimeKit;

//namespace MemberShipTenantMS_CleanArchitecture_Insfractructure.Services
//{
//    public class EmailService : IEmailService
//    {
//        private readonly EmailConfiguration _emailconfig;
//        public EmailService(EmailConfiguration emailConfiguration)
//        {
//            this._emailconfig = emailConfiguration;
//        }

//        public void SendEmail(Message message)
//        {
//            var emailMessage = CreateEmailMessage(message);
//            Send(emailMessage);
//        }

//        private MimeMessage CreateEmailMessage(Message message)
//        {
//            var emailMessage = new MimeMessage();
//            emailMessage.From.Add(new MailboxAddress("email", _emailconfig.From));
//            emailMessage.To.AddRange(message.To);
//            emailMessage.Subject = message.Subject;
//            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
//            {
//                Text = message.Content
//            };
//            return emailMessage;
//        }
//        public void Send(MimeMessage mailMessage)
//        {
//            using var client = new SmtpClient();
//            try
//            {
//                client.Connect(_emailconfig.SmtpServer, _emailconfig.Port, true);
//                client.AuthenticationMechanisms.Remove("XOAUTH2");
//                client.Authenticate(_emailconfig.UserName, _emailconfig.Password);
//                client.Send(mailMessage);
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine($"Error sending email: {ex.Message}");
//                //throw;
//            }
//            finally
//            {
//                client.Dispose();
//                client.Dispose();
//            }
//        }
//    }
//}
    

