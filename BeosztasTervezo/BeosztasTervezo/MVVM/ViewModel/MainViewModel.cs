using BeosztasTervezo.Core;
using System;

namespace BeosztasTervezo.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand ResztvevokViewCommand { get; set; }
        public RelayCommand TervezoViewCommand { get; set; }
        public RelayCommand UjresztvevoViewCommand { get; set; }
        public ResztvevokViewModel ResztvevokVM { get; set; }
        public TervezoViewModel TervezoVM { get; set; }
        public UjresztvevoViewModel UjresztvevoVM { get; set; }

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
            ResztvevokVM = new ResztvevokViewModel();
            TervezoVM = new TervezoViewModel();
            UjresztvevoVM = new UjresztvevoViewModel();
            CurrentView = ResztvevokVM;

            ResztvevokViewCommand = new RelayCommand(o =>
            {
                CurrentView = ResztvevokVM;
            });
            TervezoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TervezoVM;
            });
            UjresztvevoViewCommand = new RelayCommand(o =>
            {
                CurrentView = UjresztvevoVM;
            });
        }
    }
}
