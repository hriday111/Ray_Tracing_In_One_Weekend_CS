

using System.Drawing;
using Point3 = Vec3;
using Color = Vec3;
public class Ray
{
    public Point3 Origin {get;}
    public Vec3 Direction {get;}

    public Ray(Point3 orig, Vec3 dir)
    {
        Origin = orig;
        Direction = dir;
    }
    public static bool hit_sphere(in Point3 center, double radius, in Ray r)
    {
        Vec3 oc = center-r.Origin;
        var a = r.Direction.dot(r.Direction);
        var b = -2.0 * r.Direction.dot(oc);
        var c = oc.dot(oc) - radius*radius;
        var disc = b*b - 4*a*c;
        return disc>=0;
    }
    public Color RayColor()
    {
        if (hit_sphere(new Point3(0,0,-1), 0.5, this)){return new Color(1, 0, 0);
}       Vec3 unit_direction= this.Direction.unit_vector();
       //ColorUtils.WriteColor(Console.Out, unit_direction);
       var a = 0.5*(unit_direction[1]+1.0);
       return (1.0-a)*new Color(1.0,1.0,1.0)+ a*new Color(0.5,0.7,1);
    }
    public Point3 At(double t)
    {
        return Origin +t*Direction;
    }
}