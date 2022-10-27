using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class PointTest
    {
        public static void Run()
        {
            List<PointModel> points = new List<PointModel>
            {
                new PointModel(2, 0, 0),
                new PointModel(0, 2, 0),
                new PointModel(-2, 0, 0),
                new PointModel(0, -2, 0),
            };

            PointModel point = PointsUtils.GetAverage(points);

            Console.WriteLine($"Average point: ({point.X}, {point.Y}, {point.Z})");
        }
    }
}
