using DS.ClassLib.VarUtils;
using DS.WpfApp.Phones.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DS.WpfApp.Phones.MVVM.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private PhoneModel selectedPhone;

        public ObservableCollection<PhoneModel> Phones { get; set; }
        public PhoneModel SelectedPhone
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
            Phones = new ObservableCollection<PhoneModel>
            {
                new PhoneModel { Title="iPhone 7", Company="Apple", Price=56000 },
                new PhoneModel {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new PhoneModel {Title="Elite x3", Company="HP", Price=56000 },
                new PhoneModel {Title="Mi5S", Company="Xiaomi", Price=35000 }
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
