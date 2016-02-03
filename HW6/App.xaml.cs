using HW6.Models;
using HW6.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HW6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Company> Companies = new List<Company>()
            {
                new Company(){ Name="Моя компания", Url="vk.com/shmikel", Address="my House", Phones=null, Phones_inline="+7 903 025 6204\n+7 916 263 6838", Links=null, Links_inline=""},
                new Company(){ Name="Моя компания2", Url="vk.com/shmikel", Address="my House", Phones=null, Phones_inline="+7 903 025 6204\n+7 916 263 6838", Links=null, Links_inline=""},
                new Company(){ Name="Моя компания2", Url="vk.com/shmikel", Address="my House", Phones=null, Phones_inline="+7 903 025 6204\n+7 916 263 6838", Links=null, Links_inline=""}
                
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(Companies); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
            
        }
        
    }
}
