

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
    
    public Color RayColor(in IHittable world)
    {
        HitRecord rec;
        if(world.Hit(this, new Interval(0, RTHelpers.Infinity), out rec))
        {
            return 0.5 * (rec.Normal+new Color(1,1,1));
        }

        Vec3 unit_dir= this.Direction.unit_vector();
        var a = 0.5*(unit_dir[1]+1.0);
        return (1.0-a)*new Color(1.0,1.0,1.0) + a*new Color(0.5,0.7,1.0);

    }
    public Point3 At(double t)
    {
        return Origin +t*Direction;
    }
}