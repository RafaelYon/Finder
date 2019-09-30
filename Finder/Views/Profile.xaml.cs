using Finder.DAO;
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

            foreach (var preferenceType in preferenceTypeDAO.GetAll())
            {
                var combox = new ComboBox()
                {
                    ItemsSource = preferenceType.Values,
                    Text = preferenceType.Name
                };
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
                UserService.UpdateUser(txtEmail.Text, pbPassword.Password, pbConfirmPass.Password);
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
        }

        private void ClearFields()
        {
            txtEmail.Text = "";
            pbPassword.Password = "";
            pbConfirmPass.Password = "";
        }
    }
}
