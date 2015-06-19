using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wenskaarten
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model.WenskaartOpmaak mijnKaart = new Model.WenskaartOpmaak();
            ViewModel.WenskaartVM vm = new ViewModel.WenskaartVM(mijnKaart);
            View.WenskaartWindow mijnWenskaartView = new View.WenskaartWindow();
            
            mijnWenskaartView.DataContext = vm;
            mijnWenskaartView.Show();
        }
    }
}
