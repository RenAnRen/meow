using design.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }


        public HomeViewModel HomeMV { get; set; }
        public DiscoveryViewModel DiscoveryMV { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; 
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeMV = new HomeViewModel();
            DiscoveryMV = new DiscoveryViewModel();
            CurrentView = HomeMV;


            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeMV;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryMV;
            });
        }
    }
}
