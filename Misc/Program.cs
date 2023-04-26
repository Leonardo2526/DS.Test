using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;
using System.Diagnostics;
using Misc.StaticClassTest;
using System.Threading.Tasks;
using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Points;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using static System.Net.Mime.MediaTypeNames;
using Misc.ReflectonsTest;
using Unidecode.NET;

namespace Misc
{
    class Program
    {

        static void Main(string[] args)
        {
            //PrincipalContext context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName);
            //string loginName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //UserPrincipal user = UserPrincipal.FindByIdentity(context, loginName);
            //var u = UserPrincipal.Current;
            //string userName = u.Name; //=user.GivenName + " " + user.Surname;

            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string userName = Environment.UserName;
            Console.WriteLine(userName);
            //string s = "Привет ёжик Йогурт".Unidecode();
            //Console.WriteLine(s);
            //new MongoTest();
            //Reflections.GetAllTypes();
            Console.ReadLine();
        }

        static int GetIndex(string line)
        {
            string symb = "|";
            int charLocation = line.IndexOf(symb, StringComparison.Ordinal);

            return charLocation;
        }
    }

    public class TestClass
    {
        private string _s;

        public TestClass(string s)
        {
            _s = s;
        }

        public void Change()
        {
            _s = "new s";
        }
    }

}
