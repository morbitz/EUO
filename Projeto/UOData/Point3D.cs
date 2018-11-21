namespace System.Drawing
{
    [SerializableAttribute]
    [Runtime.InteropServices.ComVisible(true)]
    [ComponentModel.TypeConverter(typeof(PointConverter))]
    public class Point3D : PointConverter
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Z { get; set; }
        public Point3D(Int32 x, Int32 y, Int32 z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Double EuclidianDistance(Point3D Destination)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(X - Destination.X), 2) + Math.Pow(Math.Abs(Y - Destination.Y), 2) + Math.Pow(Math.Abs(Z - Destination.Z), 2));
        }
        public Point3D ManhatanDistance(Point3D Destination)
        {
            return new Point3D(Math.Abs(X-Destination.X),Math.Abs(Y-Destination.Y),Math.Abs(Z-Destination.Z));
        }
    }
}
