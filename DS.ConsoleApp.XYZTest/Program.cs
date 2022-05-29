using DS.ConsoleApp.XYZTest;


XYZ vector1 = new XYZ(1, 0, 0);
XYZ vector2 = new XYZ(0, 1, 0);
XYZ vector3 = new XYZ(0, 0, 1);

bool det = XYZOperation.Is3DOrientationEqualToOrigin(vector1, vector2, vector3);


Console.WriteLine(det);
