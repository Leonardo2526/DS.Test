using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenSegments
{
    class FindDistanceBetweenSegments
    {
        double ras(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double k, d;
            if (x1 == x2)
            { //Если отрезок вертикальный - меняем местами координаты каждой точки.
                swap(x1, y1);
                swap(x2, y2);
                swap(x3, y3);
            }
            k = (y1 - y2) / (x1 - x2);//Ищем коэффициенты уравнения прямой, которому принадлежит данный отрезок.
            d = y1 - k * x1;
            double xz = (x3 * x2 - x3 * x1 + y2 * y3 - y1 * y3 + y1 * d - y2 * d) / (k * y2 - k * y1 + x2 - x1);
            double dl = -1;
            if ((xz <= x2 && xz >= x1) || (xz <= x1 && xz >= x2)) dl = Math.Sqrt((x3 - xz) * (x3 - xz) + (y3 - xz * k - d) * (y3 - xz * k - d));//Проверим лежит ли основание высоты на отрезке.
            return dl;
        }
        int main()
        {
            double xa, xb, ya, yb, xc, xd, yc, yd, dl, dl1, dl2, dl3, dl4, min = -1, o, o1, o2, t = -2, s = -2;
            cin >> xa >> ya >> xb >> yb >> xc >> yc >> xd >> yd;
            o = (xb - xa) * (-yd + yc) - (yb - ya) * (-xd + xc);
            o1 = (xb - xa) * (yc - ya) - (yb - ya) * (xc - xa);
            o2 = (-yd + yc) * (xc - xa) - (-xd + xc) * (yc - ya);
            if (o != 0)
            {
                t = o1 / o;
                s = o2 / o;
            }
            if ((t >= 0 && s >= 0) && (t <= 1 && s <= 1)) min = 0;//Проверим пересекаются ли отрезки.
            else
            {
                //Найдём наименьшую высоту опущенную из конца одного отрезка на другой.
                dl1 = ras(xa, ya, xb, yb, xc, yc);
                min = dl1;
                dl2 = ras(xa, ya, xb, yb, xd, yd);
                if ((dl2 < min && dl2 != -1) || min == -1) min = dl2;
                dl3 = ras(xc, yc, xd, yd, xa, ya);
                if ((dl3 < min && dl3 != -1) || min == -1) min = dl3;
                dl4 = ras(xc, yc, xd, yd, xb, yb);
                if ((dl4 < min && dl4 != -1) || min == -1) min = dl4;
                if (min == -1)
                {
                    //В случае, если невозможно опустить высоту найдём минимальное расстояние между точками.
                    dl1 = sqrt((xa - xc) * (xa - xc) + (ya - yc) * (ya - yc));
                    min = dl1;
                    dl2 = sqrt((xb - xd) * (xb - xd) + (yb - yd) * (yb - yd));
                    if (dl2 < min) min = dl2;
                    dl3 = sqrt((xb - xc) * (xb - xc) + (yb - yc) * (yb - yc));
                    if (dl3 < min) min = dl3;
                    dl4 = sqrt((xa - xd) * (xa - xd) + (ya - yd) * (ya - yd));
                    if (dl4 < min) min = dl4;
                }
            }
            cout << min;
            return 0;
        }
    }
 
}
