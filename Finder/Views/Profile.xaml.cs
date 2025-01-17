﻿using Finder.DAO;
using Finder.Models;
using Finder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Finder.Views
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private PreferenceTypeDAO preferenceTypeDAO;

		private List<ComboBox> preferenceValues;

        public Profile()
        {
            InitializeComponent();

            preferenceTypeDAO = new PreferenceTypeDAO();
			preferenceValues = new List<ComboBox>();

			var userPreferences = UserService.GetLoggedUser().Preferences;

			foreach (var preferenceType in preferenceTypeDAO.GetAll())
			{
				var combox = new ComboBox()
				{
					ItemsSource = preferenceType.Values,
					Text = preferenceType.Name
				};

				combox.SelectedItem = userPreferences.Where(x => x.PreferenceType.Id == preferenceType.Id).FirstOrDefault();

				var label = new Label()
				{
					Content = preferenceType.Name,
					FontSize = 14
				};


				stpPreference.Children.Add(label);
				stpPreference.Children.Add(combox);

				preferenceValues.Add(combox);
			}
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserService.UpdateUser(txtEmail.Text, pbPassword.Password, pbConfirmPass.Password, pbOldPassword.Password);
                MessageBox.Show("Alterado com sucesso!", "Alteração de Dados", MessageBoxButton.OK, MessageBoxImage.Information );
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Alterar Dados", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnSavePreference_Click(object sender, RoutedEventArgs e)
        {
			UserService.UpdateUserPreferences(preferenceValues
				.Select(x => x.SelectedItem as PreferenceValue)
				.Where(x => x != null)
				.ToArray());
                MessageBox.Show("Salvo com sucesso!", "Preferências", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearFields()
        {
            txtEmail.Text = "";
            pbPassword.Password = "";
            pbConfirmPass.Password = "";
        }

        private void Redirecter(Window newWindow)
        {
            newWindow.Show();
            this.Close();
        }

        private void BtnMessage_Click(object sender, RoutedEventArgs e)
        {
            Redirecter(new Message());
        }

        private void BtnLogOff_Click(object sender, RoutedEventArgs e)
        {
            UserService.Loggout();
            Redirecter(new Login());
        }
    }
}
