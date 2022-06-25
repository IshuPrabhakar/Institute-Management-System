using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace IMS.Helpers
{
    public class Email
    {
        MimeMessage mime = new MimeMessage();
        SmtpClient Client = new SmtpClient();

        public void From(String NameOfTheSender, String EMailAddressOfSender)
        {
            try
            {
                mime.From.Add(new MailboxAddress(NameOfTheSender, EMailAddressOfSender));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Values connot be null");
            }
        }

        public void To(String NameOfTheRecipient, String EMailAddressOfRecipient)
        {
            try
            {
                mime.To.Add(new MailboxAddress(NameOfTheRecipient, EMailAddressOfRecipient));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Values connot be null");
            }
        }

        public void To(InternetAddressList addresses)
        {
            try
            {
                mime.To.AddRange(addresses);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Values connot be null");
            }
        }

        public void Subject(String subject)
        {
            try
            {
                mime.Subject = subject;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Values connot be null");
            }
        }

        public void Body(String body)
        {
            try
            {
                mime.Body = new TextPart("plain")
                {
                    Text = body
                };
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Values connot be null");
            }
        }

        public void GetConfig()
        {
            try
            {
                ///             Server          Port  UseSSL True/False
                Client.Connect("smtp.gmail.com", 465, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Client.Disconnect(true);
                Client.Dispose();
            }
        }
    }
}
