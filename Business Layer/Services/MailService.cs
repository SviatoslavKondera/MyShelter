using BLL.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class MailService:IMailService
    {
       public string From { get; set; }
       public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string BtnText { get; set; }


        public void SendEmail(string To,string ConfirmLink,string Subject, string PartOfBody, string BtnText)
        {
            MailMessage mm = new MailMessage(From, To);
            mm.Subject = Subject;
            mm.Body = "<!DOCTYPE html>" +
                "<link rel=\"stylesheet\" href=\"~/lib/bootstrap/dist/css/bootstrap.min.css\"/>" +
"<body>" +
            "<h3>" +
            "Привіт, " + To + " . Це команда Моніторингу Об'єктів міста.<br> " + PartOfBody +
            "</h3>" +
            "<div style=\"height:90px; \">"+
    "<a href =\"" + ConfirmLink + "\" class=\"btn btn-primary\" style=\"background-color: #0e6ccd; color: white; border: none;padding: 15px 32px; text-align: center;text-decoration: none;font-size: 16px;margin: 30px 2px;border-radius:10px;\">"+BtnText+"</a>" +
"</div>" +
"</body>" +
"</html>";
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(From, Password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }

        public void TwoFactorEmail(string To, string token, string Subject)
        {
            MailMessage mm = new MailMessage(From, To);
            mm.Subject = Subject;
            mm.Body = "Привіт, " + To + " . Це команда Моніторингу Об'єктів міста. Для входу в систему введіть код :"+token;

            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(From, Password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }

    }
}
