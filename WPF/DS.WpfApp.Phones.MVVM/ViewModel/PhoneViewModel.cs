using DS.ClassLib.Models;
using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Events;
using DS.WpfApp.Phones.MVVM.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.Phones.MVVM.ViewModel
{
    public class PhoneViewModel : Phone, IEvent<EventType>
    {

        public PhoneViewModel()
        {
            Event += Handler;
        }

        public event EventHandler<EventType> Event;
        public ICommand Command1 => new RelayCommand(c =>
        {
            Event?.Invoke(this, EventType.Apply);
        });

        void Handler(object s, EventType eventType)
        {
            MessageBox.Show($"Title: {Title}\n" +
                $"EventType: {eventType}");
        }
    }
}
