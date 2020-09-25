using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender_TikhomolovaKS
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var to = new MailAddress(txbLetter_1.Text);      //кому отправляем
            var from = new MailAddress(txbMyLogin.Text, "Robot");     //от кого отправляем

            var message = new MailMessage(from, to);  //создаем почтовое отправление

            message.Subject = txbLetter_2.Text;       //тема письма1
            message.Body = txbLetter_3.Text;          //текст письма

            //создаем клиента SMTP почты, через который будет отправляться почта
            //var client = new SmtpClient("smtp.mail.ru", 465);
            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;

            //указываем учетные данные почты клиента
            client.Credentials = new NetworkCredential
            {
                UserName = txbMyLogin.Text,
                SecurePassword = txbMyPassword.SecurePassword
            };

            //отправляем сообщение
            client.Send(message);
            MessageBox.Show("Письмо было успешно отправлено!");
        }
    }
}
