using System.Windows;
using MailSender.lib;
using System.Net;
using System.Net.Mail;
using MailSender_TikhomolovaKS.Data;
using MailSender_TikhomolovaKS.Models;

namespace MailSender_TikhomolovaKS
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //ServersList.ItemsSource = TestData.Servers;

        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs E)
        {
            var sender = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServersList.SelectedItem is Server server)) return;
            if (!(MessagesList.SelectedItem is Message message)) return;

            var send_service = new MailSenderService
            {
                SercerAddress = server.Address,
                ServerPort=server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password,
            };

            try
            {
                send_service.SendMessage(sender.Address, recipient.Address, message.Subject, message.Body);
            }
            catch (SmtpException error)
            {
                MessageBox.Show("Ошибка при отправке почты " + error.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
