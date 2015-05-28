using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WindowMetRibbonControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowMetRibbon : RibbonWindow
    {
        public WindowMetRibbon()
        {
            InitializeComponent();
            LeesMRU();
            if (WpfCursus.Properties.Settings.Default.qat != null)
            {
                System.Collections.Specialized.StringCollection qatlijst = WpfCursus.Properties.Settings.Default.qat;
                int lijnnr = 0;
                while (lijnnr < qatlijst.Count)
                {
                    string commando = qatlijst[lijnnr];
                    string png = qatlijst[lijnnr + 1];
                    RibbonButton niew = new RibbonButton();
                    BitmapImage icon = new BitmapImage();
                    icon.BeginInit();
                    icon.UriSource = new Uri(png);
                    icon.EndInit();
                    niew.SmallImageSource = icon;

                    CommandBindingCollection ccol = this.CommandBindings;
                    foreach (CommandBinding cb in ccol)
                    {
                        RoutedUICommand rcb = (RoutedUICommand)cb.Command;
                        if (rcb.Text == commando)
                        {
                            niew.Command = rcb;

                        }
                    }
                    Qat.Items.Add(niew);
                    lijnnr += 2;
                }
            }
        }


        private void LeesBestand(string bestandsnaam)
        {
            try
            {
                using (StreamReader bestand = new StreamReader(bestandsnaam))
                {
                    TextBoxVoorbeeld.Text = bestand.ReadLine();
                }
                BijwerkenMRU(bestandsnaam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".rvb";
            dlg.Filter = "Ribbon documents |*.rvb";

            if (dlg.ShowDialog() == true)
            {
                LeesBestand(dlg.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".rvb";
                dlg.Filter = "Ribbon documents |*.rvb";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(TextBoxVoorbeeld.Text);
                    }
                }
                BijwerkenMRU(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TextBoxVoorbeeld.Text = string.Empty;
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog afdrukken = new PrintDialog();
            if (afdrukken.ShowDialog() == true)
            {
                MessageBox.Show("Hier zou worden afgedrukt");
            }
        }

        private void PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hier zou een afdrukvoorbeeld moeten verschijnen");
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Dit is helpscherm", "Help", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        private void MRUGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LeesBestand(MRUGallery.SelectedValue.ToString());
        }

        private void RibbonRadioButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonRadioButton keuze = (RibbonRadioButton)sender;
            BrushConverter bc = new BrushConverter();
            SolidColorBrush kleur = (SolidColorBrush)bc.ConvertFromString(keuze.Tag.ToString());
            TextBoxVoorbeeld.Foreground = kleur;
     
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Collections.Specialized.StringCollection qatlijst = new System.Collections.Specialized.StringCollection();
            if(WpfCursus.Properties.Settings.Default.qat != null)
            {
                WpfCursus.Properties.Settings.Default.qat.Clear();
            }
            foreach (object li in Qat.Items)
            {
                if (li is RibbonButton)
                {
                    RibbonButton knop = (RibbonButton)li;
                    RoutedUICommand commando = (RoutedUICommand)knop.Command;
                    qatlijst.Add(commando.Text);
                    qatlijst.Add(knop.SmallImageSource.ToString());
                }
            }
            if (qatlijst.Count > 0)
            {
                WpfCursus.Properties.Settings.Default.qat = qatlijst;
            }
            WpfCursus.Properties.Settings.Default.Save();
        }   
        private void LeesMRU()
        {
            MRUGalleryCat.Items.Clear();
            if(WpfCursus.Properties.Settings.Default.mru != null)
            {
                System.Collections.Specialized.StringCollection mrulijst = WpfCursus.Properties.Settings.Default.mru;
                for (int lijnnr = 0; lijnnr < mrulijst.Count; lijnnr++)
                {
                    MRUGalleryCat.Items.Add(mrulijst[lijnnr]);
                }
            }
        }
        private void BijwerkenMRU(string mruNaam)
        {
            System.Collections.Specialized.StringCollection mrulijst = new System.Collections.Specialized.StringCollection();
            if(WpfCursus.Properties.Settings.Default.mru != null)
            {
                mrulijst = WpfCursus.Properties.Settings.Default.mru;
                int pos = mrulijst.IndexOf(mruNaam);
                if (pos >=0)
                {
                    mrulijst.RemoveAt(pos);
                }
                else
                {
                    if(mrulijst.Count >=6)
                    {
                        mrulijst.RemoveAt(5);
                    }
                }
            }
            mrulijst.Insert(0, mruNaam);
            WpfCursus.Properties.Settings.Default.mru = mrulijst;
            WpfCursus.Properties.Settings.Default.Save();
            LeesMRU();
        }
       
    }
    public class booleantofontweight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Boolean)value)
            {
                return "Bold";
            }
            else
            {
                return "Normal";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class booleantofontstyle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Boolean)value)
            {
                return "Italic";
            }
            else
                return "Normal";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


}

