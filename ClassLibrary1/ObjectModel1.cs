﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary1
{
    // by implementing the INotifyPropertyChanged, changes to properties
    // will update the listbox on-the-fly
    public class ObjectModel1
    {
        private string _name;

        // a property.
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

    }


}