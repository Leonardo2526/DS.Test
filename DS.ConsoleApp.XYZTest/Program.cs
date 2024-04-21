using DS.ConsoleApp.XYZTest;


XYZ vector1 = new XYZ(1, 0, 0);
XYZ vector2 = new XYZ(0, 1, 0);
XYZ vector3 = new XYZ(0, 0, 1);

//bool det = XYZOperation.Is3DOrientationEqualToOrigin(vector1, vector2, vector3);
//Console.WriteLine(det);

//XYZ crossProduct = XYZOperation.GetCrossProduct(vector1, vector2);
//Console.WriteLine($"({crossProduct.X}, {crossProduct.Y}, {crossProduct.Z})");

XYZ a = new XYZ(1, 0, 10);
XYZ b = new XYZ(-1, 0, 0);
XYZ c = new XYZ(-1, -1, 0);
//XYZ b = new XYZ(0, 1, 0);
string s;

//Console.WriteLine(XYZOperation.Collinears(a, b));
Console.WriteLine(XYZOperation.Coplanarity(a, b, c));
Console.ReadLine();

