using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DS.WpfApp.Phones.MVVM.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private PhoneViewModel selectedPhone;

        public ObservableCollection<PhoneViewModel> Phones { get; set; }
        public PhoneViewModel SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<PhoneViewModel>
            {
                new PhoneViewModel { Title="iPhone 7", Company="Apple", Price=56000 },
                new PhoneViewModel {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new PhoneViewModel {Title="Elite x3", Company="HP", Price=56000 },
                new PhoneViewModel {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
