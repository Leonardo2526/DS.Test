using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;

NameValueCollection sAll;
sAll = ConfigurationManager.AppSettings;
foreach (string s in sAll.AllKeys)
    Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));

Debug.AutoFlush = true;
//Debug.IndentSize= 50;
Debug.IndentLevel= 0;
Debug.Indent();
Debug.WriteLine("Entering Main");
Console.WriteLine("Hello World.");
Debug.WriteLine("Exiting Main");
Debug.Unindent();

Debug.WriteLine("Unindent");

Console.ReadLine();
