using System;
using Point3 = Vec3;
using Color = Vec3;

public class Sphere: IHittable
{
    private  Point3 center {get;}
    private  double radius {get;}

    private Material mat;
    public Sphere(Point3 center, double radius, Material mat)
    {   
        this.mat = mat;
        this.center = center;
        this.radius = Math.Max(0, radius);
    }
    public bool Hit(in Ray r, Interval ray_t, out HitRecord rec)
    {
        rec = new HitRecord();
        Vec3 oc = center-r.Origin;

        double a =  r.Direction.length_squared();
        var h= r.Direction.dot(oc);
        var c = oc.length_squared() - radius*radius;
        var disc = h*h - a*c; // discriminant

        if(disc<0){return false;}
        var sqrtd = Math.Sqrt(disc);

        var root = (h-sqrtd)/a;
        if(!ray_t.Surrounds(root))
        {
            root = (h+sqrtd)/a;
            if (!ray_t.Surrounds(root)) {return false;}

      
        }
        rec.T = root;
        rec.P = r.At(rec.T);
        Vec3 outward_normal = (rec.P - center) /radius;
        rec.SetFaceNormal(in r, in outward_normal);
        rec.mat = mat;
        return true;
    }

}