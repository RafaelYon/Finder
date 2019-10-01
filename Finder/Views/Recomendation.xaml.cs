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
        private List<Match> users;
        //private List<PreferenceValue> preferences;
        private User currentUser;
        private int index = 0;
        private UserRepository userRepository;
        private List<Label> labels;


        public Recomendation()
        {
            userRepository = new UserRepository();
            InitializeComponent();
            labels = LabelSeed();
            users = userRepository.GetUsersAvaliableToMatch(UserService.GetLoggedUser());            
            ChangeUserToRecomend();           

        }

        private void ChangeUserToRecomend()
        {
            try
            {
                CheckLastIndex();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Recomendação", MessageBoxButton.OK, MessageBoxImage.Information);

				Redirect(new Message());
            }
        }

        private void CheckLastIndex()
        {
            if (users.Count == index)
            {
                throw new Exception("Não há mais recomendações!");
            }
            
            currentUser = users[index++].User;
            ChangePreferenceUserRecomended();
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

        private void Redirect(Window newWindow)
        {
            newWindow.Show();
            this.Close();
        }

        private void BtnMessage_Click(object sender, RoutedEventArgs e)
        {
            Redirect(new Message());
        }

        private void ChangePreferenceUserRecomended()
        {            
            lblNameValue.Content = currentUser.Name;
            ClearFields();

            for (int i = 0; i < currentUser.Preferences.Count; i++)
            {                
                labels[i].Content = currentUser.Preferences[i].Name;
            }            
        }

        private void ClearFields()
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Content = "";
            }
        }

        private List<Label> LabelSeed()
        {
            return new List<Label>()
            {
                lblColor,
                lblMovie,
                lblMusic,
                lblAnimal,
                lblPersonality
            };
        }
    }
}
