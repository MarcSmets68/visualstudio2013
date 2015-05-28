using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;

namespace MVVMHobby.ViewModel
{
    public class HobbyDetailVM : ViewModelBase
    {
        private Model.Hobby hobby;
        public HobbyDetailVM(Model.Hobby nhobby)
        {
            hobby = nhobby;   
        }

        public string Categorie
        {
            get
            {
                return hobby.Categorie;
            }
            set
            {
                hobby.Categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }
        public string Activiteit
        {
            get
            {
                return hobby.Activiteit;
            }
            set
            {
                hobby.Activiteit = value;
                RaisePropertyChanged("Activiteit");
            }
        }
        public BitmapImage Symbool
        {
            get
            {
                return hobby.Symbool;
            }
            set
            {
                hobby.Symbool = value;
                RaisePropertyChanged("Symbool");
            }
        }
        View.ImageView groteView;
        
        public RelayCommand<MouseEventArgs> MouseDownCommand
        {
            get { return new RelayCommand<MouseEventArgs>(MuisIn); }
        }

        private void MuisIn(MouseEventArgs obj)
        {
            Image tg = (Image)obj.OriginalSource;
            groteView = new View.ImageView();
            groteView.GroteImage.Source = tg.Source;
            groteView.Show();
        }
        public RelayCommand<MouseEventArgs> MouseUpCommand
        {
            get { return new RelayCommand<MouseEventArgs>(MuisUit); }
        }

        private void MuisUit(MouseEventArgs obj)
        {
            if( groteView != null)
            {
                groteView.Close();
            }
            groteView = null;
        }



        
    }
}
