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
        public int Grootte;
        ImageBrush ib = new ImageBrush();
       
       
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

        private void NewExecuted(object sender, RoutedEventArgs e)
        {
           Nieuw();
        }

        private void Nieuw()
        {
            TextBox.Text = string.Empty;
            CanvasKaart.Background = null;
            StackPanelRechts.Visibility = Visibility.Hidden;
            TextBox.Visibility = Visibility.Hidden;
            StatusBarText.Content = "Nieuw";
            Grootte = 15;
            FontSizeLabel.Content = Grootte.ToString();
            ComboboxKleur.SelectedItem = null;
            ComboboxLetterType.SelectedItem = null;
            CanvasKaart.Children.Clear();
        }

        private void OpenExecuted(object sender, RoutedEventArgs e)
        {
            try
            {
                
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Wenskaart documents | *.txt";

                if (dlg.ShowDialog() == true)
                {
                    CanvasKaart.Children.Clear();

                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {                      
                       string LineRead = bestand.ReadLine();
                       string[] split;
                       split = LineRead.Split('*');
                       StatusBarText.Content = split[0];
                       ib.ImageSource = new BitmapImage(new Uri(@"" + split[1] , UriKind.Relative));
                       CanvasKaart.Background = ib;
                       int aantalEllipse = int.Parse(bestand.ReadLine());
                       Ellipse newEllipse;
                       BrushConverter bc = new BrushConverter();
                       for (int i = 0; i < aantalEllipse; i++)
                       { 
                           newEllipse = new Ellipse();
                           LineRead = bestand.ReadLine();
                           split = LineRead.Split('*');
                           newEllipse.Fill = (SolidColorBrush)bc.ConvertFromString(split[0]);
                           newEllipse.MouseMove += EllipseColor_MouseMove;
                           Canvas.SetLeft(newEllipse, double.Parse(split[1]));
                           Canvas.SetTop(newEllipse, double.Parse(split[2]));
                           newEllipse.Tag = split[1] + split[2];
                           CanvasKaart.Children.Add(newEllipse);                            
                       }
                       TextBox.Text = bestand.ReadLine();
                       ComboboxLetterType.SelectedItem = new FontFamily(bestand.ReadLine());
                       ComboboxKleur.SelectedItem = null;
                       string fontSize = bestand.ReadLine();
                       FontSizeLabel.Content = fontSize;
                       Grootte = int.Parse(fontSize);   
                       VisualActive();
                    }
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Openen mislukt", ex.Message);
            }
        }

        private void SaveExecuted(object sender, RoutedEventArgs e)
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
                        bestand.WriteLine(dlg.FileName.ToString() + "*" + ib.ImageSource.ToString());
                        bestand.WriteLine(CanvasKaart.Children.Count);
                        foreach  (Ellipse item in CanvasKaart.Children)
                        {
                           bestand.WriteLine(item.Fill + "*" + Canvas.GetLeft(item) + "*" + Canvas.GetTop(item));
                        }
                        bestand.WriteLine(TextBox.Text);
                        bestand.WriteLine(TextBox.FontFamily);
                        bestand.WriteLine(TextBox.FontSize);
                     }
                    StatusBarText.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Opslaan mislukt", ex.Message);
            }
        }
        private void PrintPreviewExecuted(object sender, RoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.Afdrukdocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private void CloseExecuted(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void mnuKerst_Click(object sender, RoutedEventArgs e)
        {
            Nieuw();       
            ib.ImageSource = new BitmapImage(new Uri(@"Images\kerstkaart.jpg", UriKind.Relative));
            CanvasKaart.Background = ib;
            VisualActive();
        }
        private void mnuGeboorte_Click(object sender, RoutedEventArgs e)
        {
            Nieuw();
            ib.ImageSource = new BitmapImage(new Uri(@"Images\geboortekaart.jpg", UriKind.Relative));
            CanvasKaart.Background = ib;         
            VisualActive();
        }

        private void VisualActive()
        {
            if (StackPanelRechts.Visibility == Visibility.Hidden || TextBox.Visibility == Visibility.Hidden)
            {
                StackPanelRechts.Visibility = Visibility.Visible;
                TextBox.Visibility = Visibility.Visible;
            }
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
                FontSizeLabel.Content = Grootte.ToString();
            }
        }

        private void Kleiner_Click(object sender, RoutedEventArgs e)
        {
            if (Grootte > 10)
            {
                Grootte -= 1;
                FontSizeLabel.Content = Grootte.ToString();
            }
        }
        private Ellipse sleep = new Ellipse();
        private void EllipseColor_MouseMove(object sender, MouseEventArgs e)
        {
           sleep = (Ellipse)sender;
            if (e.LeftButton == MouseButtonState.Pressed && sleep.Fill != null)
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
        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(500, 500);
            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage page = new FixedPage();
            page.Width = 500;
            page.Height = 500;
            inhoud.Child = page;

            StackPanel previewStack1 = new StackPanel();
       
            Canvas previewCanvas = new Canvas();
            previewCanvas.Width = 500;
            previewCanvas.Height = 400;
            previewCanvas.Background = CanvasKaart.Background;

            previewStack1.Children.Add(previewCanvas);

            TextBlock previewTextBlock = new TextBlock();
            previewTextBlock.Text = TextBox.Text;
            previewTextBlock.FontSize = TextBox.FontSize;
            previewTextBlock.FontFamily = TextBox.FontFamily;
            previewTextBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            previewTextBlock.Margin = new Thickness(0,25,0,0);
            previewStack1.Children.Add(previewTextBlock);

            foreach (Ellipse item in CanvasKaart.Children.OfType<Ellipse>())
            {
                Ellipse previewEllipse = new Ellipse();
                double posX = Canvas.GetLeft(item);
                double posY = Canvas.GetTop(item);
                Canvas.SetLeft(previewEllipse, posX);
                Canvas.SetTop(previewEllipse, posY);
                previewEllipse.Fill = item.Fill;
                previewCanvas.Children.Add(previewEllipse);
            }         
            page.Children.Add(previewStack1);
       
            
            return document;
        }
        
    }
}
