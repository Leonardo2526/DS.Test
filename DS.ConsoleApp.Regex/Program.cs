using DS.MainUtils.Strings;
using DS.MainUtils;


var value = "60";
//if (value.IsDevisible(10))
if (value.IsInt())
{
    Console.WriteLine($"{value} is valid.");
}
else
{
    Console.WriteLine($"{value} is not valid.");
}

Console.ReadLine();

double newValue = int.Parse(value);
//double newValue = double.Parse(value);
Console.WriteLine(newValue);


