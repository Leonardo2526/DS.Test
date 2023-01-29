using SKM.V3;
using SKM.V3.Accounts;
using SKM.V3.Methods;
using SKM.V3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static  class VerificationKey
    {
            static string licenseKey = "HIZUI-TMURZ-DHVYE-WVPWB";
            static string RSAPubKey = "<RSAKeyValue><Modulus>x8ylENxp18Nk5IOJL9D439AZifcdmVMjKcHPZJwOOhliSjX72KJBsl+EkwuKi6Dxe4jC3bNGi2qjA6nNvjhfTrYVsS8ULwxQMUPXkxmDhIizP6H7P3l7FYtxCZU5fslu1kYfqAYzWXh42lOYrrSRnspBylFIp7Dwut7OWaNlYkec3faqEVZZTyE9Qsefs/M7NqPihzTGVZkZ8ACWg4jbIPf1yRd6LRwEP23N52HCQSMV3VTU9ftZBtQ77tIl/KBNoiRD5wrTrNF3uNlbJGO8cyBR0nMdBgsOxky8LZBXqMj7K1u0WbZO5O1GMz+RXAJcAFv+UyqpJVr3Fcfb9xArpQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            static string auth = "WyIzNjUxODExOCIsIlVSU1lrTks0anBjTVpJWDdGekJ1ZXNoSHBxS013bkw5UENkMi9qTGgiXQ==";
        static int productId = 18607;

        public static void AcitvateKey1()
        {
            var result = Key.Activate(token: auth, parameters: new ActivateModel()
            {
                Key = licenseKey,
                ProductId = productId,  // <--  remember to change this to your Product Id
                Sign = true,
                MachineCode = Helpers.GetMachineCodePI(v: 2)
            });

            if (result == null || result.Result == ResultType.Error ||
                !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
            {
                // an error occurred or the key is invalid or it cannot be activated
                // (eg. the limit of activated devices was achieved)
                Console.WriteLine("The license does not work.");
            }
            else
            {
                // everything went fine if we are here!
                Console.WriteLine("The license is valid!");
                result.LicenseKey.SaveToFile();
            }

        }

        public static void GetKeys()
        {
            string existingToken = auth; // in case you've already authenticated them once and the token is still valid.

            var res = UserAccount.GetLicenseKeys(Helpers.GetMachineCodePI(v: 2), auth, "RevitPlugin", 30, RSAPubKey, existingToken);

            if (res == null || !string.IsNullOrEmpty(res.Error))
            {
                Console.WriteLine("Something went wrong.");
            }

            // if they have a license with F1=true and which has not yet expired.
            if (res.Licenses.Count(x => x.F1 == true && x.Expires >= DateTime.UtcNow && x.ProductId == 18607) > 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }

            Console.ReadLine();
        }

        public static void ActivateKey2()
        {
            var result = Key.Activate(token: auth, parameters: new ActivateModel()
            {
                Key = licenseKey,
                ProductId = 18607,
                Sign = true,
                MachineCode = Helpers.GetMachineCodePI(v: 2)
            });;

            if (result == null || result.Result == ResultType.Error ||
                !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
            {
                // an error occurred or the key is invalid or it cannot be activated
                // (eg. the limit of activated devices was achieved)
                Console.WriteLine("The license does not work.");
            }
            else
            {
                // everything went fine if we are here!
                Console.WriteLine("The license is valid!");

                if (result.LicenseKey.HasFeature(1).HasNotExpired().IsValid())
                {
                    Console.WriteLine("This is a time-limited license that is still valid in " + result.LicenseKey.DaysLeft() + " day(s).");
                }
                else if (result.LicenseKey.HasNotFeature(1).IsValid())
                {
                    Console.WriteLine("This license does not have a time limit.");
                }
                else
                {
                    Console.WriteLine("It appears this license has expired.");
                }

                if (result.LicenseKey.HasFeature(3).IsValid())
                {
                    Console.WriteLine("You have all features!");
                }
            }

        }

        public static void OffLineVerification1()
        {
            var licensefile = new LicenseKey();

            if (licensefile.LoadFromFile()
                          .HasValidSignature(RSAPubKey)
                          .IsValid())
            {
                Console.WriteLine("The license is valid!");
            }
            else
            {
                Console.WriteLine("The license does not work.");
            }
        }

        public static void OffLineVerification2()
        {
            var licensefile = SKM.V3.Methods.Helpers.VerifySDKLicenseCertificate(RSAPubKey);

            //var licensefile = new LicenseKey { ProductId = productId, Key = licenseKey };
            licensefile.SaveToFile();

            //if (licensefile.LoadFromFile("licensefile")
            //             .HasValidSignature(RSAPubKey, 3)
            //             .IsValid())

            if (licensefile.LoadFromFile("licensefile")
                          .IsValid())
            {
                Console.WriteLine("The license is valid!");
            }
            else
            {
                Console.WriteLine("The license does not work.");
            }
        }

        public static void SaveLicense()
        {

            var license = new LicenseKey { ProductId = productId, Key = licenseKey };
            license.SaveToFile();
        }
    }
}
