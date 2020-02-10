using System.Net.Mail;

namespace ZfssUZ.Helper
{
    public class EmailSender
    {
        public static void SendEmail(string emailAddress, string senderFirstName, string senderLastName, string messageContent)
        {
            var message = new MailMessage();
            message.From = new MailAddress(emailAddress);
            message.To.Add(new MailAddress("pracamagisterska2019a@gmail.com"));
            message.Subject = string.Format("Wiadomość od klienta ZFSS: {0} {1}", senderFirstName, senderLastName);
            message.Body = messageContent;

            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
