using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingBonMVVM.ViewModel
{
     public class ParkingBonVM : ViewModelBase
    {
         private Model.ParkingBon parkingbon;
         public ParkingBonVM(Model.ParkingBon deParkingBon)
         {
             parkingbon = deParkingBon;
             NieuwBon();
         }

         public DateTime Datum
         {
             get { return parkingbon.Datum; }
             set { parkingbon.Datum = value; RaisePropertyChanged("Datum");}

         }

         public string Aankomst
         {

             get { return parkingbon.Aankomst; }
             set { parkingbon.Aankomst = value; RaisePropertyChanged("Aankomst"); }
         }
         public string Vertrek
         {

             get { return parkingbon.Vertrek; }
             set { parkingbon.Vertrek = value; RaisePropertyChanged("Vertrek"); }
         }

         public string Bedrag
         {

             get { return parkingbon.Bedrag; }
             set { parkingbon.Bedrag = value; RaisePropertyChanged("Bedrag"); }
         }

         public RelayCommand NiewCommand
         {
             get { return new RelayCommand(NieuwBon); }
         }

         private void NieuwBon()
         {  
             Datum = DateTime.Today;
             Aankomst = DateTime.Now.ToLongTimeString() ;
             Vertrek = DateTime.Now.ToLongTimeString();
             Bedrag = "0 €";

         }
         public RelayCommand OpslaanCommand
         {
             get { 
                 return new RelayCommand(OpslaanBestand); }
         }
         private void OpslaanBestand()
         {
             try
             {
               
                 SaveFileDialog dlg = new SaveFileDialog();
                 dlg.FileName = Datum.Day.ToString() + '-' + Datum.Month.ToString() + '-' + Datum.Year.ToString() + "om" + Aankomst.Replace(":", "-");
                 dlg.DefaultExt = ".bon";
                 dlg.Filter = "Parkeerbonnen |*.bon";
                 if (dlg.ShowDialog() == true)
                 {
                     using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                     {
                         bestand.WriteLine(Datum.ToString());
                         bestand.WriteLine(Aankomst);
                         bestand.WriteLine(Bedrag);
                         bestand.WriteLine(Vertrek);
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
                 dlg.Filter = "Parkeerbonnen |*.bon";
                 if (dlg.ShowDialog() == true)
                 {
                     using (StreamReader input = new StreamReader(dlg.FileName))
                     {
                         Datum = Convert.ToDateTime(input.ReadLine());
                         Aankomst = input.ReadLine();
                         Bedrag = input.ReadLine();
                         Vertrek = input.ReadLine();
                     }
                 }
             }
             catch (Exception ex)
             {

                 MessageBox.Show("Openen mislukt", ex.Message);
             }
         }

         public RelayCommand MinderCommand
         {
             get { return new RelayCommand(MinderBetalen); }
         }
         private void MinderBetalen()
         {
             int teBetalen = Convert.ToInt32(Bedrag.Substring(0,Bedrag.Length-2));
             if (teBetalen > 0)
                 teBetalen -= 1;
             Bedrag = teBetalen.ToString() + " €";
             Vertrek = Convert.ToDateTime(Aankomst).AddHours(0.5 * teBetalen).ToLongTimeString();
         }

         public RelayCommand MeerCommand
         {
             get { return new RelayCommand(MeerBetalen); }
         }

         private void MeerBetalen()
         {
             int teBetalen = Convert.ToInt32(Bedrag.Substring(0, Bedrag.Length - 2));
             DateTime vertrekuur = Convert.ToDateTime(Aankomst).AddHours(0.5 * teBetalen);
             if(vertrekuur.Hour < 22)
                 teBetalen += 1;
             Bedrag = teBetalen.ToString() + " €";
             Vertrek = Convert.ToDateTime(Aankomst).AddHours(0.5 * teBetalen).ToLongTimeString();
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

        private void OnWindowClosing(CancelEventArgs obj)
        {
            if (MessageBox.Show("Afsluiten?", "Wilt u het programma sluiten?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                obj.Cancel = true;
            }
        }
    }
}
