using DS.ClassLib.Models;
using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Events;
using System;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.Phones.MVVM.Model
{
    public class PhoneModel : Phone, IEvent<EventType>
    {

        public PhoneModel()
        {
            Event += Handler;
        }

        public event EventHandler<EventType> Event;
        public ICommand Command1 => new RelayCommand(c =>
        {
            Event?.Invoke(this, EventType.Apply);
            //MessageBox.Show(Title);
        });

        void Handler(object s, EventType eventType)
        {
            MessageBox.Show(eventType.ToString());
        }
    }
}
