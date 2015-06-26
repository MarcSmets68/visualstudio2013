using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.Win32;
using System.IO;


namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            InitializeComponent();
            Nieuw();
        }


        private void Nieuw()
        { 
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            SavePrintActief(false);
            StatusView.Content = "Nieuwe Bon";
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
            SavePrintActief(!(bedrag == 0));

        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
            SavePrintActief(!(bedrag == 0));
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void SaveExecuteed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
              
                    SaveFileDialog dlg = new SaveFileDialog();
                    DateTime tijd = (DateTime)DatumBon.SelectedDate;
                    dlg.FileName = tijd.Day.ToString()+'-'+tijd.Month.ToString()+'-'+tijd.Year.ToString()+"om"+ AankomstLabelTijd.Content.ToString().Replace(":","-");
                    dlg.DefaultExt = ".bon";
                    dlg.Filter = "Parkeerbonnen |*.bon";
                    if (dlg.ShowDialog() == true)
                    {
                        using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                        {
                            bestand.WriteLine(tijd.Date.ToString());
                            bestand.WriteLine(AankomstLabelTijd.Content);
                            bestand.WriteLine(TeBetalenLabel.Content);
                            bestand.WriteLine(VertrekLabelTijd.Content);
                        }
                        StatusView.Content = dlg.FileName;
                    }
                
                
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Opslaan mislukt : "+ ex.Message);
            }
           
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Parkeerbonnen |*.bon";
                if (dlg.ShowDialog() == true)
                {
                using (StreamReader input = new StreamReader(dlg.FileName))
                {
                    DatumBon.SelectedDate = Convert.ToDateTime(input.ReadLine());
                    AankomstLabelTijd.Content = input.ReadLine();
                    TeBetalenLabel.Content = input.ReadLine();
                    VertrekLabelTijd.Content = input.ReadLine();
                } 
                SavePrintActief(true);
                StatusView.Content = dlg.FileName;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Openen mislukt : " + ex.Message);
            }
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.Afdrukdocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void SavePrintActief(bool status)
        {
            
                PrintKnop.IsEnabled = status;
                PrintMenuKnop.IsEnabled = status;
                Saveknop.IsEnabled = status;
                SaveMenuKnop.IsEnabled = status;
            
          
        }
        
        private double vertPos;
        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Margin = new Thickness(300, vertPos, 96, 96);
            deRegel.FontSize = 18;
            deRegel.Text = tekst;            
            vertPos += 36;
            return deRegel;
        }
        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(640, 320);
            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage page = new FixedPage();
            inhoud.Child = page;
            page.Width = 640;
            page.Height = 320;
            Image logo = new Image();
            logo.Source = logoImage.Source;
            logo.Margin = new Thickness(96);
            vertPos = 96;
            page.Children.Add(logo);
            page.Children.Add(Regel("datum : " + DatumBon.Text));
            page.Children.Add(Regel("starttijd : " + AankomstLabelTijd.Content));
            page.Children.Add(Regel("eindtijd :" + VertrekLabelTijd.Content));
            page.Children.Add(Regel("bedrag betaald : " + TeBetalenLabel.Content));
            return document;
        }
       
    }
}
