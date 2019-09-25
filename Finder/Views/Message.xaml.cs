using Finder.DAO;
using Finder.Models;
using Finder.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Finder.Views
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        private ChatDAO _chatDAO;
        private Chat currentChat;
        
        private ObservableCollection<Models.Message> messages;

        private ChatDAO ChatDAO
        {
            get
            {
                if (_chatDAO == null)
                    _chatDAO = new ChatDAO();

                return _chatDAO;
            }
        }

        public Message()
        {
            InitializeComponent();
            lbMatch.ItemsSource = UserService.GetLoggedUser().Chats;
        }

        private void LbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeChat(lbMatch.SelectedItem as Chat);
        }

        private void ChangeChat(Chat chat)
        {
            currentChat = chat;

            btnSend.IsEnabled = true;
            txtChat.IsEnabled = true;

            messages = new ObservableCollection<Models.Message>(currentChat.Messages);
            lvChat.ItemsSource = messages;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (currentChat == null)
            {
                return;
            }

            var message = new Models.Message(txtChat.Text);

            currentChat.Messages.Add(message);
            ChatDAO.Save(currentChat);

            messages.Add(message);
            txtChat.Text = string.Empty;
        }
    }
}
