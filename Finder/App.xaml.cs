using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Finder.DAO;
using Finder.Models;
using Finder.Services;

namespace Finder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
			//var favoriteMoveOptions = new PreferenceType
			//{
			//    Name = "Gênero de Filme"
			//};

			//var actionMovie = new PreferenceValue { Name = "Ação", PreferenceType = favoriteMoveOptions };
			//var romnanceMovie = new PreferenceValue { Name = "Romance", PreferenceType = favoriteMoveOptions };

			//favoriteMoveOptions.Values.Add(actionMovie);
			//favoriteMoveOptions.Values.Add(romnanceMovie);

			//User usr = new User();
			//usr.Preferences.Add(actionMovie);
			//usr.Preferences.Add(romnanceMovie);
        }
    }
}
