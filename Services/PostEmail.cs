using System;
using Domain.Models.SendEntities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Sevices
{
    public class PostEmail
    {
        public static void SendEmail(SenderEntity entity)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("AcheBarato", "noreplyachebarato1@gmail.com"));
                message.To.Add(new MailboxAddress(entity.UserName, entity.UserEmail));
                message.Subject = "Alerta de preço!!";

                message.Body = new TextPart("plain")
                {
                    Text = $@" Olá, {entity.UserName.Split(" ")[0]}! Vimos que você pediu para que o(a) notificasse sobre o produto {entity.ProductName} no preço de R$ {entity.ProductPrice}! Não perca tempo, clique no link e boa compra! {entity.ProductLinkRedirect}"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("noreplyachebarato1@gmail.com", "nblsgutkedovhkww");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}