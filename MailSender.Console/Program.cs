using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace MailSender.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new MailMessage("user@yandex.ru", "user@gmail.com");
            message.Subject = "Тестовое письмо";
            message.Body = $"Текст письма от {DateTime.Now}";

            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("use_name", "password");

            client.Send(message);  
        }
    }
}
