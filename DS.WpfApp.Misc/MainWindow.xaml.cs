using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace DS.WpfApp.Misc
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _gapX
        {
            get 
            {
                int dpi = ((int)Graphics.FromHwnd(IntPtr.Zero).DpiX);
                return dpi == 96 ? 7 : 0;
            }
        }

        private int _gapY
        {
            get
            {
                int dpi = ((int)Graphics.FromHwnd(IntPtr.Zero).DpiY);
                return dpi == 96 ? 7 : 0;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var scr = Screen.AllScreens;
            //Screen screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
            SetPostion();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            SetPostion();
            //var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            //this.Left = 0;
            //this.Top = desktopWorkingArea.Bottom - this.Height;

        }

        private void SetPostion()
        {
            Debug.WriteLine(Graphics.FromHwnd(IntPtr.Zero).DpiX);
            Screen currentScreen = Screen.FromPoint(System.Windows.Forms.Cursor.Position);            
            Debug.WriteLine(currentScreen.DeviceName);
            this.Left = currentScreen.WorkingArea.Left- _gapX;
            this.Top = currentScreen.WorkingArea.Bottom - (this.Height- _gapY);
        }


        private int ConvertMousePointToScreenIndex(System.Drawing.Point mousePoint)
        {
            //first get all the screens 
            System.Drawing.Rectangle ret;

            for (int i = 1; i <= Screen.AllScreens.Count(); i++)
            {
                ret = Screen.AllScreens[i - 1].Bounds;
                if (ret.Contains(mousePoint))
                    return i - 1;
            }
            return 0;
        }
    }
}
