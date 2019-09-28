using Finder.DAO;
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
            }
        }
    }
}
