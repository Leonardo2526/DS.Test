using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS.ConsoleApp.DebugTest
{
    internal static class TestClass
    {
        public static void AssertTest()
        {
            // Create an index for an array.
            int index;

            // Perform some action that sets the index.
            index = -40;

            // Test that the index value is valid.
            Trace.Assert(index > -1, "message", "details");
            //Debug.Assert(index > -1);
        }

        public static void TraceListenerTest()
        {
                Trace.AutoFlush= true;
            // Create a new stream object for an output file named TestFile.txt.
            using (FileStream myFileStream =
                new FileStream("TestFile.txt", FileMode.Append))
            {
                // Add the stream object to the trace listeners.
                TextWriterTraceListener myTextListener =
                    new TextWriterTraceListener(myFileStream);
                Trace.Listeners.Add(myTextListener);
                // Write output to the file.
                Trace.WriteLine("Test output");

                // Flush and close the output stream.
                Trace.Flush();
                Trace.Close();
            }
        }

        public static void FailTest()
        {
            string text = "value";
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                Debug.Fail("Invalid value: " + text.ToString(), "Resetting value to newValue.");
            }
        }

        public static void WriteTest(string message) 
        {
            TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");
            generalSwitch.Level = TraceLevel.Error;

            // Write the message if the TraceSwitch level is set to Error or higher.
            Debug.WriteLine(generalSwitch.Level);
            Debug.WriteIf(generalSwitch.TraceError, message);

            // Write a second message if the TraceSwitch level is set to Verbose.
            Debug.WriteLineIf(generalSwitch.TraceVerbose, " is not a valid value for this method.");
        }
    }
}
