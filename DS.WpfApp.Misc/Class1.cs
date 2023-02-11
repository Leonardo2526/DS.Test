using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DS.WpfApp.Misc
{
    internal static class Class1
    {
            [DllImport("gdi32.dll")]
            static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

            [DllImport("user32.dll")]
            static extern IntPtr GetDC(IntPtr hWnd);

            /// <summary>
            /// Logical pixels inch in X
            /// </summary>
            const int LOGPIXELSX = 88;
            /// <summary>
            /// Logical pixels inch in Y
            /// </summary>
            const int LOGPIXELSY = 90;
        public static void t()
        {
                IntPtr hdc = GetDC(IntPtr.Zero);

                Debug.WriteLine(GetDeviceCaps(hdc, LOGPIXELSX));
            // or
            Debug.WriteLine(GetDeviceCaps(hdc, LOGPIXELSY));
        }
    }
}
