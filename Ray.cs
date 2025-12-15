

using Point3 = Vec3;
using Color = Vec3;
using System.ComponentModel;
public class Ray
{
    public Point3 Origin {get;}
    public Vec3 Direction {get;}

    public Ray(Point3 orig, Vec3 dir)
    {
        Origin = orig;
        Direction = dir;
    }
    public Ray()
    {
        Origin = new Point3(0,0,0);
        Direction = new Vec3(0,0,0);
    }
    
    public Point3 At(double t)
    {
        return Origin +t*Direction;
    }
}