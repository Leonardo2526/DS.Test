using DS.ClassLib.Models;
using DS.ClassLib.VarUtils;
using System.Windows;
using System.Windows.Input;

namespace DS.WpfApp.Phones.MVVM.Model
{
    public class PhoneModel : Phone
    {
        public ICommand Command1 => new RelayCommand(c =>
        {
            MessageBox.Show(Title);
        });
    }
}
