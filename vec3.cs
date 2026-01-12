using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Numerics;
using Point3 = Vec3;
///<summary>
/// A 3D vector class representing points or colors in 3D space.
/// </summary>
public struct Vec3
{
    double[] e=new double[3];
    public double x {get; private set;}
    public double y {get; private set;}
    public double z {get; private set;}
    public Vec3()
    {
        x=0;
        y=0;
        z=0;
    }
    

    public Vec3(double e0, double e1, double e2)
    {
        x = e0;
        y = e1;
        z = e2;
    }
    

    
    public static Vec3 operator -(Vec3 v)
    {
        return new Vec3(-v.x, -v.y, -v.z);
    }

    public static Vec3 operator +(Vec3 u, Vec3 v)
    {
        return new Vec3(u.x + v.x, u.y + v.y, u.z + v.z);
    }
    
    public static Vec3 operator -(Vec3 u, Vec3 v)
    {
        return new Vec3(u.x - v.x, u.y - v.y, u.z - v.z);
    }

    public static Vec3 operator *(Vec3 v, double t)
    {
        return new Vec3(v.x * t, v.y * t, v.z * t);
    }

    public static Vec3 operator *(double t, Vec3 v)
    {
        return v * t; 
    }
    
    public static Vec3 operator *(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.x*v2.x, v1.y*v2.y, v1.z*v2.z);
    }

    public static Vec3 operator /(Vec3 v, double t)
    {
        return v * (1 / t); 
    }
    public double length_squared()
    {
        return x*x + y*y + z*z;
    }
    public double length()
    {
        return Math.Sqrt(length_squared());
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }

    public double dot( Vec3 v2)
    {
        return this.x*v2.x+ this.y*v2.y+ this.z*v2.z;
    }

    public Vec3 cross(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.y * v2.z - v1.z * v2.y,
                        v1.z * v2.x - v1.x * v2.z,
                        v1.x * v2.y - v1.y * v2.x);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vec3 unit_vector()
    {
        return this/this.length();
    }

    public static Vec3 Random()
    {
        return new Vec3(RTHelpers.RandomDouble(), RTHelpers.RandomDouble(), RTHelpers.RandomDouble());
    }

    public static Vec3 Random(double min, double max)
    {
        return new Vec3(RTHelpers.RandomDouble(min, max), RTHelpers.RandomDouble(min, max), RTHelpers.RandomDouble(min, max));
    }

    public Vec3 RandomUnitVector()
    {
        while(true)
        {
            var p = Vec3.Random(-1,1);
            var lensq = p.length_squared();
            if(1e-160< lensq && lensq<=1) {return p/Math.Sqrt(lensq);}
        }
    }
    public bool NearZero()
    {
        const double s = 1e-8;

        return(Math.Abs(x)<s) && (Math.Abs(y)<s) && (Math.Abs(z)<s);
    }

    public Vec3 RandomOnHemisphere()
    {
        var OnUnitSphere = RandomUnitVector();
        if(OnUnitSphere.dot(this)>0.0) {return OnUnitSphere;}
        else {return -OnUnitSphere;}
    }

    public Vec3 reflect(Vec3 n)
    {
        return this - 2*this.dot(n)*n;
    }

    public Vec3 refract(Vec3 n, double etai_over_etat)
    {
        var cos_theta = Math.Min(-this.dot(n), 1.0);

        Vec3 r_out_prep = etai_over_etat * (this + cos_theta*n);
        Vec3 r_out_parallel = -Math.Sqrt(Math.Abs(1-r_out_prep.length_squared()))*n;
        return r_out_prep + r_out_parallel;
    }

}

