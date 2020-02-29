using System.Net;
using System.Net.Mail;

namespace ZfssUZ.Helper
{
    public class EmailSender
    {
        public static void SendEmail(string emailAddress, string senderFirstName, string senderLastName, string messageContent)
        {
            var fromAddress = new MailAddress("pracamagisterska2019a@gmail.com", "From Name");
            var toAddress = new MailAddress("+48606873712@tmomail.net", "To Name");
            string fromPassword = "magisterka2019";
            string subject = "Konsultacja z Obsługą klienta ZFSS: " + senderFirstName + " " + senderLastName;
            string body = messageContent;


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
