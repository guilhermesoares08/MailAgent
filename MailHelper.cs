using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MailAgent
{
    public class MailHelper
    {
        public MailHelper()
        {

        }
        public static void Send(string fromAddress, string password, List<string> toAddress)
        {
            MailMessage msg = new MailMessage();
            string subject = "teste emails";
            string body = "xsl talvez";

            foreach (string email in toAddress)
            {
                msg.Bcc.Add(email);
            }

            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtps.uol.com.br",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)
            };

            msg.From = new MailAddress(fromAddress);
            msg.Subject = subject;
            msg.Body = body;
            //TODO: tratar emails nao válidos e salvar num arquivo
            try
            {
                Console.WriteLine("Enviando email...");
                client.Send(msg);
                Console.WriteLine("Email enviado!");
            }
            catch (SmtpException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message.ToString());
                Console.ResetColor();
            }
        }
    }
}
