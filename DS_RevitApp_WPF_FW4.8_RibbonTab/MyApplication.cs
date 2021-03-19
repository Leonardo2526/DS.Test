using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace DS.RevitApp.RibbonTab
{
    public class MyApplication : IExternalApplication
    {
        // class instance
        internal static MyApplication thisApp = null;


        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            string tabName = "DS_Tab";
            application.CreateRibbonTab(tabName);

            var button1Path = Environment.ExpandEnvironmentVariables(@"%AppData%\Autodesk\Revit\Addins\2020\DS_RevitTools_Net_FW_4.7.2\DS_RevitTools_Net_FW_4.7.2.dll");
            var button2Path = Environment.ExpandEnvironmentVariables(@"%AppData%\Autodesk\Revit\Addins\2020\DS_RevitTools_Net_FW_4.7.2\DS_RevitTools_Net_FW_4.7.2.dll");


            // Create two push buttons
            PushButtonData button1 = new PushButtonData("Button1", "Hello World", button1Path, "DS_RevitSpace.HelloWorld");
            PushButtonData button2 = new PushButtonData("Button2", "My Button #2", button2Path, "Revit.Test.Command2");

            // Create a ribbon panel
            RibbonPanel m_projectPanel_1 = application.CreateRibbonPanel(tabName, "DS_Panel_1");
            RibbonPanel m_projectPanel_2 = application.CreateRibbonPanel(tabName, "DS_Panel_2");

            // Add the buttons to the panel
            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.AddRange(m_projectPanel_1.AddStackedItems(button1, button2));
            projectButtons.AddRange(m_projectPanel_2.AddStackedItems(button1, button2));


            return Result.Succeeded;
        }


    }


}
