using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using static DS.ConsoleApp.DebugTest.TestClass;

Debug.WriteLine("Start Main");

//Debug.AutoFlush = true;
//Debug.IndentSize= 50;
Debug.IndentLevel= 0;
Debug.Indent();
//Debugger.Break();
//Debugger.Launch();

//FailTest();
WriteTest("test message");
//Console.WriteLine("Hello World.");

Trace.WriteLine("Executed");

Debug.Unindent();
Console.ReadLine();

