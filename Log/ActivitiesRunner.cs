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
    }
}
