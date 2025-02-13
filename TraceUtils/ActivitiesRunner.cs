﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using DS.ClassLib.FileSystemUtils;
using DS.ClassLib.VarUtils;

namespace Tracing
{
    class ActivitiesRunner
    {
        private ActivityBuilder Activity;

        public ActivitiesRunner(ActivityBuilder activity)
        {
            this.Activity = activity;
        }

        public void Run()
        {    
            this.Activity.Build();
            this.Activity.TS.Close();
        }

        public void RunWithFilter()
        {
            //save the original settings from the configuration file.  
            EventTypeFilter configFilter =
               (EventTypeFilter)Activity.TS.Listeners["WriteListener"].Filter;

            // Then create a new event type filter that ensures
            // critical messages will be written.  
            Activity.TS.Listeners["WriteListener"].Filter =  
                new EventTypeFilter(SourceLevels.Error);  

            this.Activity.Build();
            this.Activity.TS.Close();
        }

        public void RunWithNewListener()
        {

            Activity.TS.Listeners.Clear();

            DirPathBuilder pathBuilder = new DirPathBuilder();
            string dirName = pathBuilder.GetPath();

            string expDirName = Environment.ExpandEnvironmentVariables(dirName);

            StreamWriter sw = new StreamWriter(expDirName, false, Encoding.UTF8);

            var textListener = new TextWriterTraceListener(sw, "name");
            //var textListener = new TextWriterTraceListener(expDirName);
            //var textListener = new TextWriterTraceListener(@"e:\Repository\DS.WindowsApp.Tests\Log\bin\Debug\trace.txt");
            var consoleListener = new ConsoleTraceListener();

            consoleListener.Name = "TraceConsoleListener";
            textListener.Name = "TraceWriterListener";

            textListener.Write("newMes - ");
            consoleListener.WriteLine("NewLine");

            Activity.TS.Switch = new SourceSwitch("VerboseSwitch", "Verbose");
            //Activity.TS.Switch = new SourceSwitch("ErrorSwitch", "Error");

            Activity.TS.Listeners.Add(textListener);
            Activity.TS.Listeners.Add(consoleListener);
            // Write output to the file.
            //Trace.Write("Test output ");

            // Flush the output.
            //Trace.Flush();


            this.Activity.Build();
            this.Activity.TS.Close();
        }
    }
}
