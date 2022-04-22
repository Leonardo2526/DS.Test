using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    class Program
    {      
          

        static void Main(string[] args)
        {
            var activity1 = new Activity1("TraceSourceApp");

            ActivitiesRunner activities = new ActivitiesRunner(activity1);
            activities.Run();

            Console.ReadLine();
            return;
        }

     
    }
    
}
