using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wenskaarten2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Wens;
        public BitmapImage Figuur;
        public int Grootte;
        public MainWindow()
        {
            InitializeComponent();
            Grootte = 15;
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurke = new Kleur();
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
            Nieuw();
        }

        private void Nieuw_Click(object sender, RoutedEventArgs e)
        {
           Nieuw();
        }

        private void Nieuw()
        {
            TextBox.Text = string.Empty;
            CanvasKaart.Background = null;
            StackPanelRechts.Visibility = Visibility.Hidden;
            TextBox.Visibility = Visibility.Hidden;
        }

        private void Openen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".box";
                dlg.Filter = "Textbox documents | *.box";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Openen mislukt", ex.Message);
            }
        }

        private void Opslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {             
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Wenskaart";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Wenskaart documents | *.txt";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        foreach  (Ellipse item in CanvasKaart.Children)
                        {
                   
                        }
                        bestand.WriteLine();
                        bestand.WriteLine();
                        bestand.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Opslaan mislukt", ex.Message);
            }
        }
        private void Afdrukvoorbeeld_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Afsluiten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void mnuKerst_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"Images\kerstkaart.jpg", UriKind.Relative));
            CanvasKaart.Background = ib;
            StackPanelRechts.Visibility = Visibility.Visible;
            TextBox.Visibility = Visibility.Visible;
        }
        private void mnuGeboorte_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"Images\geboortekaart.jpg", UriKind.Relative));
            CanvasKaart.Background = ib;
            StackPanelRechts.Visibility = Visibility.Visible;
            TextBox.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u het programma sluiten ?", "Afsluiten",
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
            MessageBoxResult.No)
                e.Cancel = true;
        }

        private void Groter_Click(object sender, RoutedEventArgs e)
        {
            if (Grootte < 40)
            {
                Grootte += 1;
                TextBox.FontSize = Grootte;
                FontSizeLabel.Content = Grootte.ToString();
            }
        }

        private void Kleiner_Click(object sender, RoutedEventArgs e)
        {
            if (Grootte > 10)
            {
                Grootte -= 1;
                TextBox.FontSize = Grootte;
                FontSizeLabel.Content = Grootte.ToString();
            }
        }

        private Ellipse sleep = new Ellipse();
        private void EllipseColor_MouseMove(object sender, MouseEventArgs e)
        {
           sleep = (Ellipse)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {              
                DataObject sleepColor = new DataObject("deKleur", sleep.Fill);
                DragDrop.DoDragDrop(sleep, sleepColor, DragDropEffects.Move);              
            }
        }
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("deKleur"))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData("deKleur");
                Ellipse drop = new Ellipse();
                drop.Fill = gesleepteKleur;
                drop.StrokeThickness = 3;
                drop.MouseMove += EllipseColor_MouseMove; 
                Point pos = e.GetPosition(CanvasKaart);
                double posX = pos.X;
                double posY = pos.Y;
                Canvas.SetLeft(drop, posX - 20);
                Canvas.SetTop(drop, posY - 20);
                drop.Tag = posX.ToString() + posY.ToString();                
                CanvasKaart.Children.Add(drop); 
                if(sleep.Tag != null)
                {
                    CanvasKaart.Children.Remove(sleep);
                }
                               
            }
        }
        private void Vuilbak_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("deKleur"))
            {     
                CanvasKaart.Children.Remove(sleep);               
            }
        }
        
    }
}
