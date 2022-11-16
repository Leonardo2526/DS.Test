//using DS.ClassLib.Models;
using ClassLibrary1;
using DS.WpfApp.CollectionTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.CollectionTest.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MyCollection1 Objects { get; } = Class1.ObjectModels;
        public MyCollection1 Objects1 { get; } = Class1.ObjectModels1;


        private string _text = "process status";

        public MainWindowViewModel()
        {
         
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
            var items = new List<string>() { "3", "2", "1" };
            foreach (var item in items)
            {
                Class1.ObjectModels.AddItem(item);
                if (item == "1")
                {
                    //Class1.ObjectModels1.AddItem(item);
                }
            }
            Class1.Refresh(Class1.ObjectModels);
        });

        public ICommand ChangeList => new RelayCommand(o =>
        {
            foreach (var item in Class1.ObjectModels)
            {
                if (item.Name == "1")
                {
                    item.Name = "0";
                    break;
                }
            }
            //Class1.ObjectModels.Last().Name= "0";
            Class1.Refresh(Class1.ObjectModels);
        });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
