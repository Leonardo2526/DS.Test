using ConsoleApp2;
using SKM.V3;
using SKM.V3.Accounts;
using SKM.V3.Methods;
using SKM.V3.Models;


VerificationKey.GetPing();
Console.ReadLine();
return;

Console.WriteLine("Enter the key: ");
var key = Console.ReadLine();

if (String.IsNullOrEmpty(key)) 
{
    VerificationKey.OffLineVerification1();
}
else
{
    VerificationKey.AcitvateKey1(key);
}

//VerificationKey.OffLineVerification1();
//VerificationKey.ActivateKey2();

Console.ReadLine();
