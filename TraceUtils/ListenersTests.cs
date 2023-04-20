using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Tracing
{
    internal static class ListenersTests
    {
        public static void ListenersTest()
        {
            Stream myFile = File.Create("TestFile.txt");

            /* Create a new text writer using the output stream, and add it to
             * the trace listeners. */
            TextWriterTraceListener myTextListener = new
               TextWriterTraceListener(myFile);

            var consoleListener = new ConsoleTraceListener();
            consoleListener.Name = "ConsoleListener";

            var defaultListener = new DefaultTraceListener();

            Trace.Listeners.Add(myTextListener);

            // Write output to the file.
            Trace.Write("Test output ");

            // Flush the output.
            Trace.Flush();

            defaultListener.WriteLine("Output text");
            //defaultListener.Fail("Fail text");
        }

        public static void XmlTest()
        {
            File.Delete("NotEscaped.xml");
            TraceSource ts = new TraceSource("TestSource");
            ts.Listeners.Add(new XmlWriterTraceListener("NotEscaped.xml"));
            ts.Switch.Level = SourceLevels.All;
            string testString = "<Test><InnerElement Val=\"1\" /><InnerElement Val=\"Data\"/><AnotherElement>11</AnotherElement></Test>";
            XmlTextReader myXml = new XmlTextReader(new StringReader(testString));
            XPathDocument xDoc = new XPathDocument(myXml);
            XPathNavigator myNav = xDoc.CreateNavigator();
            ts.TraceData(TraceEventType.Error, 38, myNav);
            //ts.TraceEvent(TraceEventType.Error, 1,
            //    "Error message.");
            ts.Flush();
            ts.Close();

            File.Delete("Escaped.xml");
            TraceSource ts2 = new TraceSource("TestSource2");
            ts2.Listeners.Add(new XmlWriterTraceListener("Escaped.xml"));
            ts2.Switch.Level = SourceLevels.All;
            ts2.TraceData(TraceEventType.Error, 38, testString);

            ts2.Flush();
            ts2.Close();
        }

    }
}
