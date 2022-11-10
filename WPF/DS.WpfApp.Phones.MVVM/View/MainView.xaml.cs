using DS.WpfApp.Phones.MVVM.ViewModel;
using System.Windows;

namespace DS.WpfApp.Phones.MVVM.View
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();

        }
    }
}
