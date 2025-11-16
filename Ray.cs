

using System.Drawing;
using Point3 = Vec3;
public class Ray
{
    public Point3 Origin {get;}
    public Vec3 Direction {get;}

    Ray(Point3 orig, Vec3 dir)
    {
        Origin = orig;
        Direction = dir;
    }

    public Point3 At(double t)
    {
        return Origin +t*Direction;
    }
}