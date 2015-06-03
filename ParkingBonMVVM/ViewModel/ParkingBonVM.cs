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
     public class ParkingBonVM
    {
         private Model.ParkingBon parkingbon;
         public ParkingBonVM(Model.ParkingBon deParkingBon)
         {
             parkingbon = deParkingBon;
         }

         public DateTime datum
         {
             get { return parkingbon.Datum; }
             set
             {
                 parkingbon.Datum = value;
                 RaisePropertyChanged("Datum");
             }
         }
         public RelayCommand NiewCommand
         {
             get { return new RelayCommand(NieuwTextBox); }
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
                 DateTime tijd = (DateTime)ParkingBonView.DatumBon.SelectedDate;
                 dlg.FileName = tijd.Day.ToString() + '-' + tijd.Month.ToString() + '-' + tijd.Year.ToString() + "om" + AankomstLabelTijd.Content.ToString().Replace(":", "-");
                 dlg.DefaultExt = ".bon";
                 dlg.Filter = "Parkeerbonnen |*.bon";
                 if (dlg.ShowDialog() == true)
                 {
                     using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                     {
                         bestand.WriteLine(tijd.Date.ToString());
                         bestand.WriteLine(ParkingBonView.AankomstTextBlock.);
                         bestand.WriteLine(ParkingBonView.BedragLabel.Content);
                         bestand.WriteLine(ParkingBonView.VertrekTextBlock.);
                     }
                     StatusView.Content = dlg.FileName;
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

        private void OnWindowClosing(CancelEventArgs obj)
        {
            if (MessageBox.Show("Afsluiten", "Wilt u het programma sluiten?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                obj.Cancel = true;
            }
        }
    }
}
