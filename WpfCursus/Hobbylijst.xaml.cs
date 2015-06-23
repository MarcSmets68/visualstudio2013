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
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfCursus
{
    /// <summary>
    /// Interaction logic for Hobbylijst.xaml
    /// </summary>
    public partial class Hobbylijst : Window
    {
        public Hobbylijst()
        {
            InitializeComponent();
        }
        public List<Hobby> hobbies = new List<Hobby>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hobbies.Add(new Hobby("sport","voetbal",new BitmapImage(new Uri(@"imageshobby\voetbal.jpg",UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "atletiek",new BitmapImage(new Uri(@"imageshobby\atletiek.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "basketbal",new BitmapImage(new Uri(@"imageshobby\basketbal.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "tennis",new BitmapImage(new Uri(@"imageshobby\tennis.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "turnen",new BitmapImage(new Uri(@"imageshobby\turnen.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "trompet",new BitmapImage(new Uri(@"imageshobby\trompet.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "drum",new BitmapImage(new Uri(@"imageshobby\drum.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "gitaar",new BitmapImage(new Uri(@"imageshobby\gitaar.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "piano",new BitmapImage(new Uri(@"imageshobby\piano.jpg", UriKind.Relative))));

            ComboboxCategorie.Items.Add("- alle categorieën -");
            ComboboxCategorie.Items.Add("muziek");
            ComboboxCategorie.Items.Add("sport");
            ComboboxCategorie.SelectedIndex = 0;
        }

        private void ComboboxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListboxHobby.Items.Clear();
            foreach (Hobby hob in hobbies)
            {
                if(hob.Categorie == ComboboxCategorie.SelectedItem.ToString() || ComboboxCategorie.SelectedIndex == 0)
                {
                    ListboxHobby.Items.Add(hob);
                }
            }

            ListboxHobby.Items.SortDescriptions.Add(new SortDescription("Activiteit", ListSortDirection.Ascending));

        }

        private void ButtonKies_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxHobby.SelectedItem != null)
            {
                Hobby gekozenHobby = (Hobby)ListboxHobby.SelectedItem;
                //listboxGekozen.Items.Add(gekozenHobby.Categorie + " : " + gekozenHobby.Activiteit);
                listboxGekozen.Items.Add(gekozenHobby);
                listboxGekozen.Items.SortDescriptions.Add(new SortDescription("Categorie", ListSortDirection.Ascending));
                listboxGekozen.Items.SortDescriptions.Add(new SortDescription("Activiteit", ListSortDirection.Ascending));
            }
        }

        private void ButtonVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if(listboxGekozen.SelectedIndex >= 0)
            {
                listboxGekozen.Items.RemoveAt(listboxGekozen.SelectedIndex);
            }
        }

        private void ButtonSamenvatting_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Wil je de gekozen hobby's op een rijtje?","Samenvatting", MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No)== MessageBoxResult.Yes)
            {
                string mijntekst = "Mijn hobby's zijn: ";
                string cat = string.Empty;
                foreach (object item in listboxGekozen.Items)  
                {
                    Hobby mijnHobby = (Hobby)item;
                    if(cat != mijnHobby.Categorie)
                    {
                        cat = mijnHobby.Categorie;
                        mijntekst += "\n" + mijnHobby.Categorie + " : " + mijnHobby.Activiteit;
                    }
                    else 
                    {
                        mijntekst += ", " + mijnHobby.Activiteit;
                    }
                }
                if (listboxGekozen.Items.Count == 0)
                {
                    MessageBox.Show("Ik heb geen hobby's", "Samenvatting", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(mijntekst, "Samenvatting", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

       
    }
}
