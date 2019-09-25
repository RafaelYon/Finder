using Finder.Models;
using Finder.Repositories;
using Finder.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Finder.Views
{
    /// <summary>
    /// Lógica interna para Recomendation.xaml
    /// </summary>
    public partial class Recomendation : Window
    {
        private List<User> users;
        private User currentUser;
        private int index = 0;
        private UserRepository userRepository;
        public Recomendation()
        {
            userRepository = new UserRepository();
            InitializeComponent();
            try
            {
                users = userRepository.GetUsersAvaliableToMatch(UserService.GetLoggedUser());
                ChangeUserToRecomend();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Preferências", MessageBoxButton.OK, MessageBoxImage.Information);
            }            
        }

        private void ChangeUserToRecomend()
        {
            try
            {
                CheckLastIndex();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Recomendação", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CheckLastIndex()
        {
            if (users.Count == index)
            {
                throw new Exception("Não há mais recomendações!");
            }

            currentUser = users[index++];
            txtName.Text = currentUser.Name;
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            // Adiciona o metodo
            userRepository.CreateMatch(UserService.GetLoggedUser(), currentUser);
            ChangeUserToRecomend();      
        }

        private void BtnDecline_Click(object sender, RoutedEventArgs e)
        {
            ChangeUserToRecomend();
        }
    }
}
