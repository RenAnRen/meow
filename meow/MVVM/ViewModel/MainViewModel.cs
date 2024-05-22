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
        public RelayCommand ContractorViewCommand { get; set; }
        public RelayCommand ContractorsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand MeetViewCommand { get; set; }
        public RelayCommand MeetsViewCommand { get; set; }

        public HomeViewModel HomeMV { get; set; }
        public ContractorViewModel ContractorMV { get; set; }
        public ContractorsViewModel ContractorsMV { get; set; }
        public SettingsViewModel SettingsMV { get; set; }
        public MeetViewModel MeetMV { get; set; }
        public MeetsViewModel MeetsMV { get; set; }

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
            ContractorMV = new ContractorViewModel();
            ContractorsMV = new ContractorsViewModel();
            SettingsMV = new SettingsViewModel();
            MeetMV = new MeetViewModel();
            MeetsMV = new MeetsViewModel();

            CurrentView = HomeMV;


            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeMV;
            });

            ContractorViewCommand = new RelayCommand(o =>
            {
                CurrentView = ContractorMV;
            });

            ContractorsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ContractorsMV;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsMV;
            });

            MeetViewCommand = new RelayCommand(o =>
            {
                CurrentView = MeetMV;
            });

            MeetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = MeetsMV;
            });
        }
    }
}
