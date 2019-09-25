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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserService.Login(txtEmail.Text, passwordBox.Password);
                Recomendation asdf = new Recomendation();
                asdf.Show();
                this.Close();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Falha ao entrar!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
        }

        private void BtnSingUp_Click(object sender, RoutedEventArgs e)
        {
            Redirect(new Register());
        }

        private void Redirect(Window newWindow)
        {
            newWindow.Show();
            this.Close();
        }
    }
}
