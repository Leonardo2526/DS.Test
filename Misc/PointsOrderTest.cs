using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class PointsOrderTest
    {
        public static void Run()
        {
            var p1 = new PointModel(0, 0, 0);
            var p2 = new PointModel(0, 10, 0);
            var p3 = new PointModel(0, 2, 10);
            var p4 = new PointModel(0, 5, 0);

            List<PointModel> points = new List<PointModel> { p1, p2, p3, p4 };
            points = points.OrderBy(obj => obj.DistanceTo(p1)).ToList();

            foreach (var point in points)
            {
                Console.WriteLine($"({point.X}, {point.Y}, {point.Z})\n");
            }
        }
    }
}
