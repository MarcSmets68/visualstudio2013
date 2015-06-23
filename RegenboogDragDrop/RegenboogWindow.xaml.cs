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

namespace RegenboogDragDrop
{
    /// <summary>
    /// Interaction logic for WindowRegenboog.xaml
    /// </summary>
    public partial class WindowRegenboog : Window
    {
        public WindowRegenboog()
        {
            InitializeComponent();
        }
        private Rectangle sleepRh = new Rectangle();
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            sleepRh = (Rectangle)sender;
            if((e.LeftButton == MouseButtonState.Pressed)&& (sleepRh.Fill != Brushes.White))
            {
                DataObject sleepKl = new DataObject("deKleur",sleepRh.Fill);
                DragDrop.DoDragDrop(sleepRh, sleepKl, DragDropEffects.Move);
            }
        }

        private void RecTangle_DragEnter(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 5;
        }

        private void RecTangle_DragLeave(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 3;
        }

        private void RecTangle_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent("deKleur"))
            {
                Brush gesleepteKl = (Brush)e.Data.GetData("deKleur");
                Rectangle rH = (Rectangle)sender;
                if(rH.Fill == Brushes.White)
                {
                    rH.Fill = gesleepteKl;
                    sleepRh.Fill = Brushes.White;
                }
                rH.StrokeThickness = 3;
            }
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            foreach (Rectangle rH in DropZone.Children)
            {
                string naam = rH.Name.Substring(4);
                Brush naamKl = (Brush)new BrushConverter().ConvertFromString(naam);
                Brush kl = rH.Fill;
                if(naamKl == kl)
                {
                    rH.Stroke = Brushes.Green;
                }
                else
                {
                    rH.Stroke = Brushes.Red;
                }
            }
        }

        
    }
}

