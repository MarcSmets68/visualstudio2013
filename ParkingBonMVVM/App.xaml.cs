using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingBonMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model.ParkingBon bon = new Model.ParkingBon();
            ViewModel.ParkingBonVM vm = new ViewModel.ParkingBonVM(bon);
            View.ParkingBonView mijnView = new View.ParkingBonView();
            mijnView.DataContext = vm;
            mijnView.Show();
        }
    }
}
