using Finder.Services;
using System;
using System.Windows;

namespace Finder.Views
{
    /// <summary>
    /// Lógica interna para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserService.Register(txtName.Text, txtEmail.Text, txtPassword.Password, txtPass.Password);
                ViewRedirecter(new Profile());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Falha ao registrar", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            ViewRedirecter(new Login());
        }

        private void ViewRedirecter(Window newWindow)
        {
            newWindow.Show();
            this.Close();
        }
    }
}
