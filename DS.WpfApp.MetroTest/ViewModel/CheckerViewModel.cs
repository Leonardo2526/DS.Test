using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DS.WpfApp.MetroTest.ViewModel
{
    internal class CheckerViewModel : INotifyPropertyChanged
    {
        private bool _checker1State;
        private bool _checker2State;
        private bool _allCheckersState;

        public CheckerViewModel()
        {
            _checker1State = true;
            _checker2State = true;
            _allCheckersState = true;
        }


        public bool Checker1State
        {
            get { return _checker1State; }
            set { _checker1State = value; OnPropertyChanged("Checker1State"); }
        }
        public bool Checker2State
        {
            get { return _checker2State; }
            set { _checker2State = value; OnPropertyChanged("Checker2State"); }
        }
        public bool AllCheckersState
        {
            get { return _allCheckersState; }
            set { 
                _allCheckersState = value;

                if (!_allCheckersState)
                {
                    _checker1State = false;
                    _checker2State = false;
                }
                OnPropertyChanged("Checker1State"); 
                OnPropertyChanged("Checker2State");
                OnPropertyChanged("AllCheckersState"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
