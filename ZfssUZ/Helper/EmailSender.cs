using System.Net;
using System.Net.Mail;
using ZfssUZ.Enums;

namespace ZfssUZ.Helper
{
    public class EmailSender
    {
        public static void SendEmail(string contactFormValue, string senderFirstName, string senderLastName, string messageContent, int messageTypeId)
        {
            var fromAddress = new MailAddress("pracamagisterska2019a@gmail.com", senderFirstName + " " + senderLastName + " (" + contactFormValue + ")");
            var toAddress = messageTypeId == (int)eMessageType.PhoneNumber ? new MailAddress("+48726763203@text.plusgsm.pl", "To Name") : new MailAddress("xadero2@gmail.com", "To Name");
            var fromPassword = "magisterka2019";
            var subject = "Kontakt z Obsluga klienta ZFSS";
            var body = messageContent;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
            {
                smtp.Send(message);
            }
        }
    }
}
