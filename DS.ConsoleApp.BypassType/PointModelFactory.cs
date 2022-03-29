
namespace DS.ConsoleApp.BypassType
{
    abstract class PointModelFactory
    {
        abstract public PointGroup CreateL0(double p1, double p2);
        abstract public PointGroup CreateL1(double p1, double p2);
    }

}
