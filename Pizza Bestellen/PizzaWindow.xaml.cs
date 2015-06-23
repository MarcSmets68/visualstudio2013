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

namespace Pizza_Bestellen
{
    /// <summary>
    /// Interaction logic for PizzaWindow.xaml
    /// </summary>
    public partial class PizzaWindow : Window
    {
        public PizzaWindow()
        {
            InitializeComponent();
        }

        private void Bestellen_Click(object sender, RoutedEventArgs e)
        {
            string tekst = "U heeft " + aantalLabel.Content + " ";
            string ingredienten = string.Empty;
            foreach(FrameworkElement child in boxen.Children)
            {
                if (child is RadioButton)
                {
                    if(((RadioButton)child).IsChecked == true )
                    {
                        tekst += child.Name + @"pizza('s) besteld met: ";
                    }
                }
                if (child is CheckBox)
                {
                    if(((CheckBox)child).IsChecked == true)
                    {
                        ingredienten += child.Name + ", ";
                    }
                }
            }
                ingredienten = ingredienten.Substring(0, ingredienten.Length - 2);
                int k = ingredienten.LastIndexOf(",");
                ingredienten = ingredienten.Substring(0, k) + " en " + ingredienten.Substring(k + 2);
                tekst += ingredienten + "\n";
            if (extrakorst.IsChecked == true)
            {
                tekst += "met extra dikke korst";
            }
            if(extrakaas.IsChecked == true)
            {
                tekst += " overstrooid met extra kaas";
            }
            order.Content = tekst;
           

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(aantalLabel.Content);
            if(aantal<10)
                aantal++;
            aantalLabel.Content = aantal.ToString();
            
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(aantalLabel.Content);
            if (aantal > 1)
                aantal--;
            aantalLabel.Content = aantal.ToString();
        }
    }
}
