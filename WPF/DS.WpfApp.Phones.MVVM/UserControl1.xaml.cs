using DS.WpfApp.Phones.MVVM.ViewModel;
using System.Windows;

namespace DS.WpfApp.Phones.MVVM
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : Window
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}
