using System.Net;
using System.Net.Mail;

namespace web
{
    public class MailClient
    {
        public static void sendMail(string to, string subject, string htmlBody)
        {
            SmtpClient smtp = new SmtpClient();

            MailMessage msg = new MailMessage();
            msg.To.Add(to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = htmlBody;

            smtp.Send(msg);

            smtp.Dispose();
        }
    }
}