using DS.MainUtils;
using DS.TraceUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Tracing
{
    class Program
    {      
          

        static void Main(string[] args)
        {

            TestLib();

            //TestInternal();

            Console.ReadLine();
            return;
        }


        static void CheckSwitcher()
        {
            System.Diagnostics.TraceSwitch myTraceSwitch =
new System.Diagnostics.TraceSwitch("SwitchOne", "The first switch");
            myTraceSwitch.Level = System.Diagnostics.TraceLevel.Info;
            // This message box displays true, because setting the level to
            // TraceLevel.Info sets all lower levels to true as well.  
            Console.WriteLine(myTraceSwitch.TraceWarning.ToString());
            //// This message box displays false.  
            Console.WriteLine(myTraceSwitch.TraceVerbose.ToString());

            Console.WriteLine(myTraceSwitch.Level);
            Console.WriteLine(myTraceSwitch.Description);
        }

        static void TestInternal()
        {
            string message = "- test message";

            //var activity1 = new Activity1("TraceSourceApp1");
            var activity2 = new Activity2("TraceSource", message);

            ActivitiesRunner activities = new ActivitiesRunner(activity2);
            //activities.Run();
            //activities.RunWithFilter();
            activities.RunWithNewListener();

            //activities = new ActivitiesRunner(activity2);
            //activities.Run();

            Console.WriteLine();

            //CheckSwitcher();
        }

        static void TestLib()
        {

            LogBuilder logBuilder = new LogBuilder();
            logBuilder.ClearLog();

            logBuilder.AddMessage("new error message", TraceEventType.Error);
            logBuilder.AddMessage("new warning message", TraceEventType.Warning);
            logBuilder.AddMessage("new text");

            //DirPathBuilder pathBuilder = new DirPathBuilder("NewLogFile", "", DirPathBuilder.DirOption.Desktop);
        }

    }
    
}
