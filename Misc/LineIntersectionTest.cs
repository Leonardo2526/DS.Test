using DS.MainUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class LineIntersectionTest
    {
        public void RunTest()
        {
            var list1 = new List<int>
        { 1,2,3,4,5};

            var list2 = new List<int>
        { 0,2,9};

            var intersections = ListIntersection.GetIntersections(list1, list2);

            Console.WriteLine("Intersections: ");
            foreach (var item in intersections)
            {
                Console.WriteLine(item);

            }

            var NoIntersections = ListIntersection.GetNoIntersections(list1, list2);

            Console.WriteLine("\nNoIntersections: ");
            foreach (var item in NoIntersections)
            {
                Console.WriteLine(item);

            }
        }
       
    }
}
