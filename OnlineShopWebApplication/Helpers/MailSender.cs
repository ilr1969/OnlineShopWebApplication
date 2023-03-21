using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace OnlineShopWebApplication.Helpers
{
    public class MailSender
    {
        public void SendEmail(string subhect, string body, string recipient)
        {
            using var emailMessage = new MimeMessage();
            emailMessage.Date = DateTime.Now;
            emailMessage.Subject = subhect;
            emailMessage.Body = new TextPart()
            {
                Text = body
            };
            emailMessage.From.Add(new MailboxAddress("", "test@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", recipient));

            using var client = new SmtpClient();
            client.Connect("smtp.yandex.ru", 465, true);
            client.Authenticate("test", "pass");
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}
