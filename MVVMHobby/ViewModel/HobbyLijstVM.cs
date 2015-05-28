using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace MVVMHobby.ViewModel
{
    public class HobbyLijstVM : ViewModelBase
    {
        private ObservableCollection<HobbyDetailVM> loadedHobbies = new ObservableCollection<HobbyDetailVM>();
        public HobbyLijstVM(Model.HobbyLijst nHobbyLijst)
        {
                if (nHobbyLijst != null)
                {
                    foreach (var item in nHobbyLijst.Hobbies)
                    {
                        loadedHobbies.Add(new HobbyDetailVM(item));
                    }
                }
        }
        private ObservableCollection<HobbyDetailVM> hobbies;
        public ObservableCollection<HobbyDetailVM> Hobbies
        {
            get
            {
                return hobbies;
            }
            set
            {
                hobbies = value;
                RaisePropertyChanged("Hobbies");
            }
        }
        private HobbyDetailVM selectedHobby;
        public HobbyDetailVM SelectedHobby
        {
            get
            {
                return selectedHobby;
            }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged("SelectedHobby");
            }
        }
        public RelayCommand LoadHobbiesCommand
        {
            get { return new RelayCommand(LoadedHobbies); }
        }

        private void LoadedHobbies()
        {
            Hobbies = loadedHobbies;
        }

    }
}
