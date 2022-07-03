using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.MetroTest.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private bool progresStatus;
        public bool ProgresStatus
        {
            get 
            { 
                return progresStatus; 
            }
            set
            {
                progresStatus = value;
                //MessageBox.Show("PropChanged");
                OnPropertyChanged("ProgresStatus");
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }


        public ICommand Start => new RelayCommand(o =>
        {
            ProgresStatus = true;
            //MessageBox.Show("RunCommand");
        });

        public ICommand Stop => new RelayCommand(o =>
        {
            ProgresStatus = false;
            //Text = "newText";
            //MessageBox.Show("StopCommand");
        });


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
