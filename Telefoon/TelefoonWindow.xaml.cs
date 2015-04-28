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
using System.ComponentModel;
using System.Media;

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
        public List<Persoon> personen = new List<Persoon>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            personen.Add(new Persoon("Vader","011/871043","Familie",new BitmapImage(new Uri(@"images\vader.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Grotezus","011/871043","Familie",new BitmapImage(new Uri(@"images\grotezus.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Kleinezus","011/871043","Familie",new BitmapImage(new Uri(@"images\kleinezus.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Collega1","011/871043","Werk",new BitmapImage(new Uri(@"images\collega1.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Collega2","011/871043","Werk",new BitmapImage(new Uri(@"images\collega2.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Collega3","011/871043","Werk",new BitmapImage(new Uri(@"images\collega3.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Anne","011/871043","Vrienden",new BitmapImage(new Uri(@"images\anne.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Ed","011/871043","Vrienden",new BitmapImage(new Uri(@"images\ed.jpg",UriKind.Relative))));
            personen.Add(new Persoon("Bob","011/871043","Vrienden",new BitmapImage(new Uri(@"images\bob.jpg",UriKind.Relative))));
            

            ComboBoxSelectie.Items.Add("Iedereen");
            ComboBoxSelectie.Items.Add("Familie");
            ComboBoxSelectie.Items.Add("Vrienden");
            ComboBoxSelectie.Items.Add("Werk");
            ComboBoxSelectie.SelectedIndex = 0;
        }

        private void ComboBoxSelectie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxleden.Items.Clear();
            foreach (Persoon pers in personen)
	        {
		 if(pers.Groep == ComboBoxSelectie.SelectedItem.ToString()||ComboBoxSelectie.SelectedIndex == 0)
         {
             ListBoxleden.Items.Add(pers);
         }
	        }
            ListBoxleden.Items.SortDescriptions.Add(new SortDescription("Groep", ListSortDirection.Ascending));
        }

        private void Bellen_Click(object sender, RoutedEventArgs e)
        {
            if(ListBoxleden.SelectedItem == null)
            {
                MessageBox.Show("Je moet eerst iemand selecteren", "Niemand gekozen", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                
                Persoon selectie = (Persoon)ListBoxleden.SelectedItem;
                string text = "Wil je " + selectie.Naam + " bellen" +"\n" + "op het nummer: " + selectie.Telefoonnr;
                if (MessageBox.Show(text, "Telefoon", MessageBoxButton.YesNo, MessageBoxImage.Question,MessageBoxResult.No)==MessageBoxResult.Yes)
                {
                    SoundPlayer speler = new SoundPlayer("PHONE.wav");
                    speler.Play();
                }
                
            }
            
        }
    }
}
