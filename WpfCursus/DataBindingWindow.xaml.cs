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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public Persoon pers = new Persoon("Jan");
        public DataBindingWindow()
        {
            InitializeComponent();
            SortDescription sd = new SortDescription("Source", ListSortDirection.Ascending);
            lettertypeCombobox.Items.SortDescriptions.Add(sd);
            lettertypeCombobox.SelectedItem = new FontFamily("Arial");
            veranderTextBox.DataContext = pers;
        }

        private void toonNaamButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pers.Naam);
        }

        private void veranderButton_Click(object sender, RoutedEventArgs e)
        {
            pers.Naam = "piet";
        }
    }
}
