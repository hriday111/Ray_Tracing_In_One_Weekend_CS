using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Numerics;
using Point3 = Vec3;
public class Vec3
{
    double[] e=new double[3];
    public Vec3()
    {
        e[0]=0;
        e[1]=0;
        e[2]=0;
    }
    

    public Vec3(double e0, double e1, double e2)
    {
        e = new double[] {e0, e1, e2};
    }
    public double this[int i]
    {
        get => e[i];
        set => e[i] = value;
    }

    
    public static Vec3 operator -(Vec3 v)
    {
        return new Vec3(-v[0], -v[1], -v[2]);
    }

    public static Vec3 operator +(Vec3 u, Vec3 v)
    {
        return new Vec3(u[0] + v[0], u[1] + v[1], u[2] + v[2]);
    }
    
    public static Vec3 operator -(Vec3 u, Vec3 v)
    {
        return new Vec3(u[0] - v[0], u[1] - v[1], u[2] - v[2]);
    }

    public static Vec3 operator *(Vec3 v, double t)
    {
        return new Vec3(v[0] * t, v[1] * t, v[2] * t);
    }

    public static Vec3 operator *(double t, Vec3 v)
    {
        return v * t; 
    }
    
    public static Vec3 operator *(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1[0]*v2[0], v1[1]*v2[1], v1[2]*v2[2]);
    }

    public static Vec3 operator /(Vec3 v, double t)
    {
        return v * (1 / t); 
    }
    public double length_squared()
    {
        return e[0]*e[0] + e[1]*e[1] + e[2]*e[2];
    }
    public double length()
    {
        return Math.Sqrt(length_squared());
    }

    public override string ToString()
    {
        return $"({e[0]}, {e[1]}, {e[2]})";
    }

    public double dot( Vec3 v2)
    {
        return this[0]*v2[0]+ this[1]*v2[1]+ this[2]*v2[2];
    }

    public Vec3 cross(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1[1] * v2[2] - v1[2] * v2[1],
                        v1[2] * v2[0] - v1[0] * v2[2],
                        v1[0] * v2[1] - v1[1] * v2[0]);
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

        return(Math.Abs(e[0])<s) && (Math.Abs(e[1])<s) && (Math.Abs(e[2])<s);
    }

    public Vec3 RandomOnHemisphere()
    {
        var OnUnitSphere = RandomUnitVector();
        if(OnUnitSphere.dot(this)>0.0) {return OnUnitSphere;}
        else {return -OnUnitSphere;}
    }

    public Vec3 reflect(Vec3 v2)
    {
        return this - 2*this.dot(v2)*v2;
    }

}

