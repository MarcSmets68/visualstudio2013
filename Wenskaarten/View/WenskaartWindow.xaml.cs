using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wenskaarten.View
{
    /// <summary>
    /// Interaction logic for WenskaartWindow.xaml
    /// </summary>
    public partial class WenskaartWindow : Window
    {
        public WenskaartWindow()
        {
            InitializeComponent();
             foreach (PropertyInfo info in typeof(Colors).GetProperties())
             {
                 BrushConverter bc = new BrushConverter();
                 SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                 Model.Kleur kleurke = new Model.Kleur();
                 kleurke.Borstel = deKleur;
                 kleurke.Naam = info.Name;
                 kleurke.Hex = deKleur.ToString();
                 kleurke.Rood = deKleur.Color.R;
                 kleurke.Groen = deKleur.Color.G;
                 kleurke.Blauw = deKleur.Color.B;
                 ComboboxKleur.Items.Add(kleurke);
                 SortDescription sd = new SortDescription("Source", ListSortDirection.Ascending);
                 ComboboxLetterType.Items.SortDescriptions.Add(sd);
                 
             }
        }

        

        //private void MenuItem_Geboorte(object sender, RoutedEventArgs e)
        //{
        //    ImageBrush imageBrush = new ImageBrush();
        //    imageBrush.ImageSource = new BitmapImage(new Uri("geboortekaart.jpg", UriKind.Relative));
        //    Canvas.Background = imageBrush;
        //}
        
        
    }
}
