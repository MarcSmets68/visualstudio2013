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

        private Rectangle sleep = new Rectangle();
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            sleep = (Rectangle)sender;
            if((e.LeftButton == MouseButtonState.Pressed) && (sleep.Fill) != Brushes.White)
            {
                DataObject sleepColor = new DataObject("deKleur", sleep.Fill);
                DragDrop.DoDragDrop(sleep, sleepColor, DragDropEffects.Move);
            }
        }

        private void Rectangle_DragEnter(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 5;
        }

        private void Rectangle_DragLeave(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 3;
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent("deKleur"))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData("deKleur");
                Rectangle rechthoek = (Rectangle)sender;
                if (rechthoek.Fill == Brushes.White)
                {
                    rechthoek.Fill = gesleepteKleur;
                    sleep.Fill = Brushes.White;
                }
                rechthoek.StrokeThickness = 3;
            }
        }

       
    }
}

