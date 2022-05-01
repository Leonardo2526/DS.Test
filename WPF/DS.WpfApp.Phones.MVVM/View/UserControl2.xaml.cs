using DS.WpfApp.Phones.MVVM.ViewModel;
using System.Windows;

namespace DS.WpfApp.Phones.MVVM.View
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : Window
    {
        public UserControl2()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();

        }
    }
}
