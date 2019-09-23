using Finder.DAO;
using Finder.Models;
using Finder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Finder.Views
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }

        private void LbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbMatch.ItemsSource = UserService.GetLoggedUser().Chats;
        }
    }
}
