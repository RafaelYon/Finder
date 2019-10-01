using Finder.Models;
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

        private Genre genre;

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserService.Register(txtName.Text, txtEmail.Text, txtPassword.Password, txtPass.Password, dpborn.SelectedDate, genre);
                ViewRedirecter(new Login());
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

        private void RbFemale_Checked(object sender, RoutedEventArgs e)
        {
            genre = Genre.Female;
        }

        private void RbMale_Checked(object sender, RoutedEventArgs e)
        {
            genre = Genre.Male;
        }
    }
}
