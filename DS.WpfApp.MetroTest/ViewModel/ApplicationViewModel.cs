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
        public CancellationTokenSource s_cts;

        public List<Thread> currentThreads = new List<Thread>();

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
        Client client;

        public ICommand Start => new RelayCommand(async o =>
        {
            ProcessLaunched = true;
            Text = "Process launched";
            //_cancellationTokenSource = new CancellationTokenSource();
            //currentThreads.Add(Thread.CurrentThread);

            //client = new Client();
            //await Task.Run(() => client.Run());

            s_cts = new CancellationTokenSource();

            Model model = new Model(this);
            await Task.Run(() => model.Task1());

            //await Task.Run(() => model.WrapTask(_cancellationTokenSource), _cancellationTokenSource.Token);
            //await Task.Run(() => model.WrapTask1(s_cts));
            //await model.RunProcessAsync();
            //await Task.Run(() => Model.Task3().TimeoutAfter(3000));

            //await model.ListenAsync(s_cts.Token);
            //await Task.Run(() => Model2.LongRunningOperationWithCancellationTokenAsync(1000, s_cts.Token));
            //await Task.Run(() => Model2.LongRunningOperation(1000), s_cts.Token);
            //MessageBox.Show("ProcessCompleted");
            ProcessLaunched = false;
            //Text = "Process completed";
            //await Model.Task3();
            //await model.RunProcessAsync();
            //MessageBox.Show("RunCommand");
        });

        [Obsolete]
        public ICommand Stop => new RelayCommand(o =>
        {
            //client.Kill();
            //currentThreads.First().Suspend();
            s_cts.Cancel();
            //foreach (var thread in currentThreads)
            //{
            //    if (thread.ThreadState == System.Threading.ThreadState.Running)
            //    {
            //        thread.Suspend();
            //    }
            //}

            ProcessLaunched = false;
            //Environment.Exit(0);
            //Text = "Process stoped";
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
