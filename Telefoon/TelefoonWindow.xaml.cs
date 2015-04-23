using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telefoon
{
    /// <summary>
    /// Interaction logic for TelefoonWindow.xaml
    /// </summary>
    public partial class TelefoonWindow : Window
    {
        public TelefoonWindow()
        {
            InitializeComponent();
        }
        public List<Persoon> personen = new List<Persoon>; 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSelectie.Items.Add("Iedereen");
            ComboBoxSelectie.Items.Add("Familie");
            ComboBoxSelectie.Items.Add("Vrienden");
            ComboBoxSelectie.Items.Add("Werk");
            ComboBoxSelectie.SelectedIndex = 0;
        }
    }
}
