using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DS.ClassLib.Models
{
    // by implementing the INotifyPropertyChanged, changes to properties
    // will update the listbox on-the-fly
    public class ObjectModel1
    {
        private int _id;


        // a property.
        public int Id { get; set; }


    }


}