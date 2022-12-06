using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Events;
using DS.WpfApp.Phones.MVVM.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.Phones.MVVM.ViewModel
{
    public class PhoneViewModel : Phone, IEvent<EventType>, INotifyPropertyChanged
    {

        public PhoneViewModel()
        {
            CommandEnabled = true;
            _enabled = true;
        }

        private bool _commandEnabled;
        public bool CommandEnabled
        {
            get { return _commandEnabled; }
            set
            {
                _commandEnabled = value;
                OnPropertyChanged("CommandEnabled");
            }
        }

        public event EventHandler<EventType> Event;

        private NewRelayCommand _cmd1;
        public ICommand Cmd1
        {
            get
            {
                Debug.Print("Getter property Cmd1");
                if (this._cmd1 == null) this._cmd1 = new NewRelayCommand(CmdExec1, CanCmdExec1);
                return this._cmd1;
            }
        }

        private bool CanCmdExec1(object obj) => _enabled;

        private void CmdExec1(object obj)
        {
            this._enabled = !_enabled;
            this._cmd1.RaiseCanExecuteChanged();
            CommandManager.InvalidateRequerySuggested();
            Debug.Print("CmdExec1");
        }

        private NewRelayCommand _cmd2;
        public ICommand Cmd2
        {
            get
            {
                Debug.Print("Getter property Cmd2");
                if (this._cmd2 == null) this._cmd2 = new NewRelayCommand(CmdExec2, CanCmdExec2);
                return this._cmd2;
            }
        }

        private bool _enabled;

        private bool CanCmdExec2(object obj) => _enabled;

        private void CmdExec2(object obj) => Debug.Print("CmdExec2");
    





    public ICommand Command2
        {
            get
            {
                var command = new NewRelayCommand(a =>
                { CommandEnabled = false; });
                command.RaiseCanExecuteChanged();

                //CommandEnabled = false;

                //Debug.WriteLine($"{Command2.CanExecute(this)}");

                //Debug.WriteLine("Command executed!");
                return command;
            }
        }


        public ICommand Command1 => new RelayCommand(c =>
        {
            Command2.Execute(c);

            //CommandEnabled = false;

            Debug.WriteLine($"{Command1.CanExecute(this)}");

            Debug.WriteLine("Command executed!");

        }, o => CommandEnabled);

        public ICommand Command1Async => new RelayCommand(async c =>
        {
            //Event?.Invoke(this, EventType.Apply);

            //Task task = Task.Run(() => CommandEnabled = false);
            //await task;

            CommandEnabled = false;
            CommandManager.InvalidateRequerySuggested();
            await Task.Delay(1);

            //Debug.WriteLine($"{Command1.CanExecute(this)}");

            Debug.WriteLine("Command executed!");

        }, o => CommandEnabled);

        void Handler(object s, EventType eventType)
        {
            Debug.Write($"Title: {Title}\n" +
                $"EventType: {eventType}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
