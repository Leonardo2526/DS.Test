using DS.WpfApp.MetroTest.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DS.WpfApp.MetroTest.View
{
    /// <summary>
    /// Interaction logic for ChekerWidow.xaml
    /// </summary>
    public partial class CheckerView : Window
    {
        public CheckerView()
        {
            InitializeComponent();
            DataContext = new CheckerViewModel();
        }
    }
}
