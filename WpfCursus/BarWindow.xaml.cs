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
    /// Interaction logic for BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public static RoutedCommand mijnRouteCtrlB = new RoutedCommand();
        public static RoutedCommand mijnRouteCtrlI = new RoutedCommand();
        public BarWindow()
        {
            InitializeComponent();

            //CommandBinding mijnCtrlB = new CommandBinding(mijnRouteCtrlB, ctrlBExecuted);
            //this.CommandBindings.Add(mijnCtrlB);
            //KeyGesture toetsCtrlB = new KeyGesture(Key.B, ModifierKeys.Control);
            //KeyBinding mijnKeyCtrlB = new KeyBinding(mijnRouteCtrlB, toetsCtrlB);
            //this.InputBindings.Add(mijnKeyCtrlB);

            //CommandBinding mijnCtrlI = new CommandBinding(mijnRouteCtrlI, ctrlIExecuted);
            //this.CommandBindings.Add(mijnCtrlI);
            //KeyGesture toetsCtrlI = new KeyGesture(Key.I, ModifierKeys.Control);
            //KeyBinding mijnKeyCtrlI = new KeyBinding(mijnRouteCtrlI, toetsCtrlI);
            //this.InputBindings.Add(mijnKeyCtrlI);

        }

        private void ctrlBExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }
        private void ctrlIExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }
        private void Vet_Aan_Uit()
        {
            if(TextBoxVoorbeeld.FontWeight == FontWeights.Normal)
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                MenuVet.IsChecked = true;
                ButtonVet.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                MenuVet.IsChecked = false;
                ButtonVet.IsChecked = false;
            }
        }

        private void MenuVet_Click(object sender, RoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }

        private void Schuin_Aan_Uit()
        {
            if (TextBoxVoorbeeld.FontStyle == FontStyles.Normal)
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                Menuschuin.IsChecked = true;
                ButtonSchuin.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                Menuschuin.IsChecked = false;
                ButtonSchuin.IsChecked = false;
            }
        }

        private void MenuSchuin_Click(object sender, RoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void Lettertype_Click(object sender, RoutedEventArgs e)
        {
            MenuItem hetLettertype = (MenuItem)sender;
            foreach (MenuItem huidig in Fontjes.Items)
            {
                huidig.IsChecked = false;
            }
            hetLettertype.IsChecked = true;
            LettertypeComboBox.SelectedItem = new FontFamily(hetLettertype.Header.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LettertypeComboBox.Items.SortDescriptions.Add(new SortDescription("Source", ListSortDirection.Ascending));
            LettertypeComboBox.SelectedItem = new FontFamily(TextBoxVoorbeeld.FontFamily.ToString());
        }

        private void LettertypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (MenuItem huidig in Fontjes.Items)
            {
                if(LettertypeComboBox.SelectedItem.ToString() == huidig.Header.ToString())
                {
                    huidig.IsChecked = true;
                }
                else
                {
                    huidig.IsChecked = false;
                }
            }
        }

    }
}
