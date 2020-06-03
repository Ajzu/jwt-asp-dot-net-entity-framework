using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Utilities
{
    public class ExternalCommunication
    {
        private readonly PasswordManager _passwordManager;

        public ExternalCommunication()
        {
            _passwordManager = new PasswordManager();
        }

        public void SendMail(string to, string otp)
        {
            try
            {
                //string samplepassword = "zicomog8506*";
                //string encrypt = GetEncryptedPassword(samplepassword);
                //string decrypt = GetDecryptedPassword(encrypt);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTPDetail.Host);// "smtp.gmail.com");

                mail.From = new MailAddress(GetDecryptedPassword(SMTPDetail.From));
                mail.To.Add(to);
                mail.Subject = "[Important] Forgot Password Link";
                mail.Body = "OTP is " + otp;
                //Attachment attachment = new Attachment(filename);
                //mail.Attachments.Add(attachment);
                SmtpServer.Port = SMTPDetail.Port;// 587;//25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("arjun22singh009@gmail.com", GetDecryptedPassword(SMTPDetail.Password));
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public string GetEncryptedPassword(string password)
        {
            return _passwordManager.Encrypt(password);
        }

        public string GetDecryptedPassword(string password)
        {
            return _passwordManager.Decrypt(password);
        }
    }
    public class SMTPDetail
    {
        public SMTPDetail()
        {

        }
        public static string From = ConfigurationManager.AppSettings["Sender"];
        //public const string From = ConfigurationManager.AppSettings["SMTPFrom"].ToString();//"pgopi3727@gmail.com";
        //public const string Fromname = "pgopi3727@gmail.com";
        //public const string Username = "AKIAJWDHIZJFF6VR3FCA";
        //public const string Password = "AqDoPuT6lg6UE8WIaSHpzuxpKiFVnazlo+i1wp9gjhMg";
        public static string Password = ConfigurationManager.AppSettings["SenderDetail"];
        public const string Configset = "";
        //public const string Host = "smtp.gmail.com";
        public static string Host = ConfigurationManager.AppSettings["Host"];//"smtp.gmail.com";
        //public const int Port = 587;
        public static int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);//587;
    }
}
