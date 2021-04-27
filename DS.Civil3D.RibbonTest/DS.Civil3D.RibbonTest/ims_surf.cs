//civil 3d assemblies
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
//for ribbon controls
using Autodesk.Windows;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace SurfaceTool
{
    public class SEXPORT : IExtensionApplication
    {
        Editor ed;
        [CommandMethod("ims_surf")]
        public void ims_surf()
        {
            //throw new NotImplementedException(); 
            if (Autodesk.Windows.ComponentManager.Ribbon == null)
            {
                //load the custom Ribbon on startup, but at this point
                //the Ribbon control is not available, so register for 
                //an event and wait
                Autodesk.Windows.ComponentManager.ItemInitialized +=
                    new EventHandler<RibbonItemEventArgs>
                      (ComponentManager_ItemInitialized);
            }
            else
            {
                //the assembly was loaded using NETLOAD, so the ribbon
                //is available and we just create the ribbon
                cr();
            }
            cr();
            Autodesk.AutoCAD.ApplicationServices.Application.SystemVariableChanged += TrapWSCurrentChange;
        }


        #region Initializing and termination members
        public void Initialize()
        {          
            //throw new NotImplementedException(); 
            if (Autodesk.Windows.ComponentManager.Ribbon == null)
            {
                //load the custom Ribbon on startup, but at this point
                //the Ribbon control is not available, so register for
                //an event and wait
                Autodesk.Windows.ComponentManager.ItemInitialized +=
                    new EventHandler<RibbonItemEventArgs>
                      (ComponentManager_ItemInitialized);
            }
            else
            {
                //the assembly was loaded using NETLOAD, so the ribbon
                //is available and we just create the ribbon
                cr();
            }
            cr();
            Autodesk.AutoCAD.ApplicationServices.Application.SystemVariableChanged += TrapWSCurrentChange;
        }

        private void ComponentManager_ItemInitialized(object sender, RibbonItemEventArgs e)
        {
            //now one Ribbon item is initialized, but the Ribbon control
            //may not be available yet, so check if before
            if (Autodesk.Windows.ComponentManager.Ribbon != null)
            {
                //ok, create Ribbon
                cr();
                //and remove the event handler
                Autodesk.Windows.ComponentManager.ItemInitialized -=
                    new EventHandler<RibbonItemEventArgs>
                      (ComponentManager_ItemInitialized);
            }

        }

        //solving workspace changing
        public void TrapWSCurrentChange(object sender, Autodesk.AutoCAD.ApplicationServices.SystemVariableChangedEventArgs e)
        {
            if (e.Name.Equals("WSCURRENT"))
            {
                cr();
            }
        }

        public void cr()
        {
            RibbonTab tab1 = CreateRibbon("ESOL Tool");
            if (tab1 == null)
            {
                return;
            }

            RibbonPanelSource rpannel = CreateButtonPannel("ESOL Tool", tab1);
            if (rpannel == null)
            {
                return;
            }


            RibbonButton b1 = CreateButton("Surface Tool", "ims_surf", "SurfaceTool.SurfaceIcon.png", rpannel);
            //RibbonButton b2 = CreateButton("Profile Tool", "EXP1", "RibbonInCivil.Profile.png", rpannel);



        }


        public void Terminate()
        {
            //throw new NotImplementedException();
            ed.WriteMessage("\n --------------------");
        }

        private RibbonTab CreateRibbon(string str)
        {
            //1. Create ribbon control
            RibbonControl rc = ComponentManager.Ribbon;
            //2. Create ribbon tab
            RibbonTab rt = new RibbonTab();
            //3. ribbon tab information assignment
            rt.Title = str;
            rt.Id = str;

            //4. add ribbon tab to the ribbon control's tab
            rc.Tabs.Add(rt);
            //5. optional: set ribbon tab active
            rt.IsActive = true;
            return rt;
        }

        private RibbonPanelSource CreateButtonPannel(string str, RibbonTab rtab)
        {
            //1. Create  panel source
            RibbonPanelSource bp = new RibbonPanelSource();

            //3. ribbon panel source information assignment
            bp.Title = str;
            //4. create ribbon pannel
            RibbonPanel rp = new RibbonPanel();
            //4. add ribbon pannel to the ribbon pannel source
            rp.Source = bp;
            //5. add ribbon pannel to the tobs
            rtab.Panels.Add(rp);
            return bp;

        }

        private RibbonButton CreateButton(string str, string CommandParameter, string pngFile, RibbonPanelSource rps)
        {
            //1. Create  Button
            RibbonButton button = new RibbonButton();


            //3. ribbon panel source information assignment
            button.Text = str;
            button.Id = str;
            button.CommandParameter = CommandParameter; // name of the command
            button.ShowImage = true;
            button.ShowText = true;
            button.Size = RibbonItemSize.Large;

            button.Orientation = Orientation.Vertical; // from system.windows.controls

            //if(Utilities134.LoadPNGImageFromResource("logo.png") != null)
            //    button.LargeImage = Utilities134.LoadPNGImageFromResource("logo.png");
            //else
            //    if (Utilities134.LoadPNGImageFromResource("rib134.logo.png") != null)
            button.LargeImage = Utilities134.LoadImage(pngFile);

            // 4. to add command to the button write the line below
            button.CommandHandler = new AdskCommandHandler();

            //5. add ribbon button pannel to the ribbon pannel source
            rps.Items.Add(button);
            return button;

        }

        private RibbonButton CreateButton1(string str, string CommandParameter, string pngFile, RibbonPanelSource rps)
        {
            //1. Create  Button
            RibbonButton button = new RibbonButton();


            //3. ribbon panel source information assignment
            button.Text = str;
            button.CommandParameter = CommandParameter; // name of the command
            button.Orientation = Orientation.Vertical; // from system.windows.controls
            button.Size = RibbonItemSize.Large;
            //button.LargeImage = LaodImage("imageName.ext");
            button.ShowImage = false;
            button.ShowText = true;
            //button.LargeImage = Utilities134.LoadPNGImageFromResource("logo.png");
            // 4. to add command to the button write the line below
            button.CommandHandler = new AdskCommandHandler();
            button.LargeImage = Utilities134.LoadImage(pngFile);

            //5. add ribbon button pannel to the ribbon pannel source
            rps.Items.Add(button);
            return button;

        }

        #endregion
    }
    public class AdskCommandHandler : System.Windows.Input.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //is from a Ribbon Button?
            RibbonButton ribBtn = parameter as RibbonButton;
            if (ribBtn != null)
            {
                string cmdName = (String)ribBtn.CommandParameter;

                // remove all empty spaces and add
                // a new one at the end.
                cmdName = cmdName.TrimEnd() + " ";

                // execute the command using command prompt
                Application.DocumentManager.MdiActiveDocument.
                  SendStringToExecute(cmdName,
                  true, false, true);
            }
        }
    }

    public class Utilities134
    {
        //checking of Civil 3d existence
        public static bool IsCivil3D
        {
            get
            {
                return (HostApplicationServices.Current.UserRegistryProductRootKey.Contains("000"));
            }
        }

        public static System.Windows.Media.ImageSource LoadImage(string name)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = GetEM(name);
            bi.EndInit();
            return bi;

        }
        public static Stream GetEM(string rname)
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(rname);
        }


        //Native function
        #region PInvoke to avoid 'Not Responding' status

        /// <summary>
        /// Process Windows messages to avoid 'Not Responding' state
        /// </summary>
        public static void AvoidNotResponding()
        {
            Utilities134.NativeMessage msg;
            Utilities134.PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;

        }

        // We won't use this maliciously
        [System.Security.SuppressUnmanagedCodeSecurity]
        [System.Runtime.InteropServices.DllImport("User32.dll",
          CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool PeekMessage(out NativeMessage msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        #endregion
    }
}