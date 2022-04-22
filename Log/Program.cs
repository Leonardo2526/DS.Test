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
            var activity1 = new Activity1("TraceSourceApp1");
            var activity2 = new Activity1("TraceSourceApp2");

            ActivitiesRunner activities = new ActivitiesRunner(activity1);
            activities.Run();

            activities = new ActivitiesRunner(activity2);
            activities.Run();

            Console.WriteLine();

            //CheckSwitcher();

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

    }
    
}
