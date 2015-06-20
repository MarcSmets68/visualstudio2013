using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wenskaarten.ViewModel
{
     public class WenskaartVM : ViewModelBase

    {
         private Model.WenskaartOpmaak opmaakKaart;
         public WenskaartVM(Model.WenskaartOpmaak deKaart)
         {
             opmaakKaart = deKaart;
             NieuwKaart();
            
         }

         public string Wens
         {
             get { return opmaakKaart.Wens; }
             set { opmaakKaart.Wens = value; RaisePropertyChanged("Wens"); }
         }
         public BitmapImage Figuur
         {
             get { return opmaakKaart.Figuur; }
             set { opmaakKaart.Figuur = value; RaisePropertyChanged("Figuur"); }
         }

         public RelayCommand NieuwCommand
         {
             get { return new RelayCommand(NieuwKaart); }
         }
         private void NieuwKaart()
         {
             Wens = string.Empty; 
         }
         public RelayCommand OpslaanCommand
         {
             get { return new RelayCommand(OpslaanBestand); }
         }
         private void OpslaanBestand()
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
         public RelayCommand OpenenCommand
         {
             get { return new RelayCommand(OpenenBestand); }
         }
         private void OpenenBestand()
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
         public RelayCommand AfsluitenCommand
         {
             get { return new RelayCommand(AfsluitenApp); }
         }
         private void AfsluitenApp()
         {
             Application.Current.MainWindow.Close();
         }

        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get { return new RelayCommand<CancelEventArgs>(OnWindowClosing); }
        }
        public void OnWindowClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u het programma sluiten ?","Afsluiten", 
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
            MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
