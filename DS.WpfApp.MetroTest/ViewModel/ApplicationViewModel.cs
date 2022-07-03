using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.MetroTest.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public Thread currentThread;

        private bool processLaunched;
        public bool ProcessLaunched
        {
            get 
            { 
                return processLaunched; 
            }
            set
            {
                processLaunched = value;
                //MessageBox.Show("PropChanged");
                OnPropertyChanged("ProcessLaunched");
            }
        }

        private string text="process status";
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }


        public ICommand Start => new RelayCommand(async o =>
        {
            ProcessLaunched = true;
            Text = "Process launched";

            Model model = new Model(this);
            await model.RunProcessAsync();


            //await Model.Task3();
            //await Task.Run(() => Model.RunProcess(this));
            //MessageBox.Show("RunCommand");
        });

        [Obsolete]
        public ICommand Stop => new RelayCommand(o =>
        {
            currentThread.Suspend();

            ProcessLaunched = false;
            //Environment.Exit(0);
            Text = "Process stoped";
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
