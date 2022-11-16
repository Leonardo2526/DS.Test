using System.Windows;

namespace DS.RVT.ExtCmd.FW4._8.MVVM1
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public NamesCollection MyObjects { get; set; } = new NamesCollection();

        public StartWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            string name = "1";
            MyObjects.Add(name);
        }
    }
}
