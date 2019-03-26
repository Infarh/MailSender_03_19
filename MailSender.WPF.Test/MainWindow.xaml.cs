using System;
using System.Windows;

using System.Net;
using System.Net.Mail;

namespace MailSender.WPF.Test
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var user_name = UserNameTextBox.Text;
            var user_password = PasswordBoxEditor.SecurePassword;

            const string host = "smtp.yandex.ru";
            const int port = 25;

            try
            {
                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(user_name, user_password);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress("user@yandex.ru", "От меня");
                        message.To.Add(new MailAddress("user@gmail.com", "Ко мне"));
                        message.Subject = "Тестовое письмо";
                        message.Body = $"Письмо от {DateTime.Now}";

                        //message.Attachments.Add(new Attachment());

                        client.Send(message);
                    }
                }

                MessageBox.Show("Письмо успешно отправлено!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка отправки почты",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }                                 
        }
    }
}
