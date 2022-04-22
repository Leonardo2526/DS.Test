using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tracing
{
    class ActivitiesRunner
    {
        private AbstractActivity Activity;

        public ActivitiesRunner(AbstractActivity activity)
        {
            this.Activity = activity;
        }

        public void Run()
        {    
            this.Activity.Create();
            this.Activity.TS.Close();
        }

        public void RunWithFilter()
        {
            //save the original settings from the configuration file.  
            EventTypeFilter configFilter =
               (EventTypeFilter)Activity.TS.Listeners["ConsoleListener"].Filter;

            // Then create a new event type filter that ensures
            // critical messages will be written.  
            Activity.TS.Listeners["ConsoleListener"].Filter =  
                new EventTypeFilter(SourceLevels.Error);  

            this.Activity.Create();
            this.Activity.TS.Close();
        }
    }
}
