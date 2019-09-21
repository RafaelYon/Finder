using Finder.DAO;
using Finder.Models;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private User user = new User();

        public Register()
        {
            InitializeComponent();
        }

        private void TxtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Name = txtNome.Text;
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Email = txtEmail.Text;
        }

        private void TxtSenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            user.Password = txtSenha.Text;
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
            if(user != null)
            {
                UserDAO.Save(user);
                MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Nenhum campo deve estar vazio!", "Falha", MessageBoxButton.OK);
            }
        }
    }
}
