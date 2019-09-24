using Finder.DAO;
using Finder.Models;
using Finder.Repositories;
using Finder.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public Recomendation()
        {
            InitializeComponent();
            users = (new UserRepository).GetUsersAvaliableToMatch(UserService.GetLoggedUser());
        }

        private void ChangeUserToRecomend()
        {
            currentUser = users[index++];

            ListView.ItemsSourceProperty = currentUser.Preferences;
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            // Adiciona o metodo
            new UserRepository().CreateMatch(UserService.GetLoggedUser(), currentUser);
            ChangeUserToRecomend();
        }
    }
}
