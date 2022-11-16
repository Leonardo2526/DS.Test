//using DS.ClassLib.Models;
using ClassLibrary1;
using DS.WpfApp.CollectionTest.Model;
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

namespace DS.WpfApp.CollectionTest.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //private MyCollection1 _objects;

        //public MyCollection1 Objects
        //{
        //    get { return _objects; }
        //    set { _objects = value; OnPropertyChanged(nameof(ObjectModel1)); }
        //}


        public MyCollection1 Objects { get; } = Class1.ObjectModels;
        public MyCollection1 Objects1 { get; } = Class1.ObjectModels1;


        private string _text = "process status";

        public MainWindowViewModel()
        {
            //Objects = Class1.ObjectModels;
            //Objects = new MyCollection1();
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Text"); }
        }

        public ICommand Start => new RelayCommand(o =>
        {
            MyModel model = new MyModel(this);
            model.Task1();
        });

        public ICommand AddItem => new RelayCommand(o =>
        {
            var items = new List<string>() { "1", "2", "3" };
            foreach (var item in items)
            {
                Class1.ObjectModels.AddItem(item);
                if (item == "1")
                {
                    Class1.ObjectModels1.AddItem(item);
                }
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
