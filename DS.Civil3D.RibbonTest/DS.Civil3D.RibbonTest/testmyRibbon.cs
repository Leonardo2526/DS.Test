//using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;
using System;
using System.Windows.Input;

namespace AutoCADTest
{
    public class Class1
    {
        [CommandMethod("testmyRibbon", CommandFlags.Transparent)]
        public void Testme()
        {
            Autodesk.Windows.RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon != null)
            {
                RibbonTab rtab = ribbon.FindTab("TESTME");
                if (rtab != null)
                {
                    ribbon.Tabs.Remove(rtab);
                }
                rtab = new RibbonTab();
                rtab.Title = "TEST  ME";
                rtab.Id = "Testing";
                //Add the Tab
                ribbon.Tabs.Add(rtab);
                addContent(rtab);
            }
        }

        static void addContent(RibbonTab rtab)
        {
            rtab.Panels.Add(AddOnePanel());
        }

        static RibbonPanel AddOnePanel()
        {
            RibbonButton rb;
            RibbonPanelSource rps = new RibbonPanelSource();
            rps.Title = "Test One";
            RibbonPanel rp = new RibbonPanel();
            rp.Source = rps;

            //Create a Command Item that the Dialog Launcher can use,
            // for this test it is just a place holder.
            RibbonButton rci = new RibbonButton();
            rci.Name = "TestCommand";

            //assign the Command Item to the DialgLauncher which auto-enables
            // the little button at the lower right of a Panel
            rps.DialogLauncher = rci;
            // создаем кнопку
            Autodesk.Windows.RibbonButton button1 = new Autodesk.Windows.RibbonButton();
            button1.Id = "_button1";
            // привязываем к кнопке обработчик нажатия
            rb = new RibbonButton();
            rb.CommandHandler = new CommandHandler_Button1();
            rb.Name = "Test Button";
            rb.ShowText = true;
            rb.Text = "Test Button";
            //Add the Button to the Tab
            rps.Items.Add(rb);
            return rp;
        }
        // обработчик нажатия кнопки

    }
    public class CommandHandler_Button1 : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public bool CanExecute(object param)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("DS_RenameStyles\n", true, false, false);
        }
    }
}
