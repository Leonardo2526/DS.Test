using SingletonPattern;
using System;

var single1 = Singleton.GetInstance();
single1.Name = "newName";
var single2 = Singleton.GetInstance();

//var op1 = new Operation();
//var op2 = new Operation();

//Console.WriteLine(op1.Equals(op2));

Console.WriteLine(single1.Equals(single2));
Console.WriteLine(single1.Name);
Console.WriteLine(single2.Name);
Console.WriteLine(Singleton.Count);


