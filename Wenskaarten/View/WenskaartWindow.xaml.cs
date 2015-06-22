using GalaSoft.MvvmLight.Command;
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
using System.Windows.Shapes;

namespace Wenskaarten.View
{
    /// <summary>
    /// Interaction logic for WenskaartWindow.xaml
    /// </summary>
    public partial class WenskaartWindow : Window
    {
        private Model.WenskaartOpmaak opmaakKaart;
         private int Grootte = 15;
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
             NieuwCommand();
             FontGrootte = Grootte.ToString();
        
        }              
           

         public string Wens
         {
             get { return opmaakKaart.Wens; }
             set { opmaakKaart.Wens = value;  }
         }
         public BitmapImage Figuur
         {
             get { return opmaakKaart.Figuur; }
             set { opmaakKaart.Figuur = value; ; }
         }

         public string FontGrootte
         {
             get { return opmaakKaart.FontGrootte; }
             set { opmaakKaart.FontGrootte = value;  }
         }
             
         private void NieuwCommand()
         {
             Wens = string.Empty;
             Figuur = null;
             
         }
         private void OpslaanCommand()
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
         private void OpenenCommand()
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
         
         private void AfsluitenCommand()
         {
             Application.Current.MainWindow.Close();
         }
        public void ClosingCommand(CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u het programma sluiten ?","Afsluiten", 
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
            MessageBoxResult.No)
                e.Cancel = true;
        } 
        
        
         private void GroterCommand()
         {
             if (Grootte< 40)
             {
                 Grootte += 1;
                 FontGrootte = Grootte.ToString();
             }

         }       
         private void KleinerCommand()
         {
             if (Grootte > 10)
             {
                 Grootte -= 1;
                 FontGrootte = Grootte.ToString();
             }

         }      
         private void SelectKerstkaartCommand()
         {
             Figuur = new BitmapImage(new Uri("kerstkaart.jpg",UriKind.Relative));
         }
            
         private void SelectGeboortekaartCommand()
         {
             Figuur = new BitmapImage(new Uri("geboortekaart.jpg", UriKind.Relative));

         }

      
    }
}
