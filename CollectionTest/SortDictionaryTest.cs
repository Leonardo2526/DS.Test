using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    internal static class SortDictionaryTest
    {
        public static void Run()
        {
            List<string> list1 = new List<string>() { "a", "b", "c" };
            List<string> list2 = new List<string>() { "a", "b", "c", "d" };

            Dictionary<string, int> keyValuePairs = CombineLists(list1, list2);

            OutputValues(keyValuePairs);
            var dict = keyValuePairs.OrderBy(obj => obj.Value).ToDictionary(pair => pair.Key, pair => pair.Value);         
            Console.WriteLine();
            OutputValues(dict);
        }

        private static Dictionary<string, int> CombineLists(List<string> list1, List<string> list2)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    int sum = i + j;
                    string s = list1[i] + list2[j];
                    keyValuePairs.Add(s, sum);
                }
            }

            return keyValuePairs;
        }

        private static void OutputValues(Dictionary<string, int> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

    }
}
