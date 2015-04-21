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

namespace Verkeerslicht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool groen_pressed = false;
        public MainWindow()
        {
            InitializeComponent();
            Rood.Opacity = 1;
            Oranje.Opacity = 0;
            Groen.Opacity = 0;
            ButtonOrange.IsEnabled = true;
            ButtonRed.IsEnabled = false;
            ButtonGreen.IsEnabled = false;
            ButtonOrange.Background = new SolidColorBrush(Colors.Orange);
            ButtonGreen.Background = new SolidColorBrush(Colors.Green);
            ButtonRed.Background = new SolidColorBrush(Colors.Red);
            
        }

        private void Button_Go(object sender, RoutedEventArgs e)
        {
            if (Rood.Opacity == 1)
            {
                Rood.Opacity = 0;
                Oranje.Opacity = 1;
                ButtonGreen.IsEnabled = false;
                ButtonOrange.IsEnabled = true;
                groen_pressed = true;
            }
            else
            {

                Groen.Opacity = 1;
                Oranje.Opacity = 0;
                ButtonGreen.IsEnabled = false;
                ButtonRed.IsEnabled = true;
            }
            
            
        }

        private void Button_Opgelet(object sender, RoutedEventArgs e)
        {
            if (Rood.Opacity == 1)
            {
                Rood.Opacity = 0;
                Oranje.Opacity = 1;
                ButtonOrange.IsEnabled = false;     
                ButtonGreen.IsEnabled = true;
            }
            else if (groen_pressed == false)
            {
                Oranje.Opacity = 0;
                Rood.Opacity = 1;
                ButtonOrange.IsEnabled = false;
                ButtonGreen.IsEnabled = true;
            }
            else
            {
                Oranje.Opacity = 0;
                Groen.Opacity = 1;
                ButtonOrange.IsEnabled = false;
                ButtonRed.IsEnabled = true;
                groen_pressed = false;
            }


        }

        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            Oranje.Opacity = 1;
            Groen.Opacity = 0;
            ButtonRed.IsEnabled = false;
            ButtonOrange.IsEnabled = true;
        }

        

      
       
    }
}
