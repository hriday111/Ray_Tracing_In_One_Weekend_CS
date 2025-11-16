using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Numerics;
using point3 = vec3;
public class vec3
{
    double[] e=new double[3];
    public vec3()
    {
        e[0]=0;
        e[1]=0;
        e[2]=0;
    }
    

    public vec3(double e0, double e1, double e2)
    {
        e = new double[] {e0, e1, e2};
    }
    public double this[int i]
    {
        get => e[i];
        set => e[i] = value;
    }

    public static vec3 operator -(vec3 v)
    {
        return new vec3(-v[0], -v[1], -v[2]);
    }

    public static vec3 operator +(vec3 u, vec3 v)
    {
        return new vec3(u[0] + v[0], u[1] + v[1], u[2] + v[2]);
    }
    
    public static vec3 operator -(vec3 u, vec3 v)
    {
        return new vec3(u[0] - v[0], u[1] - v[1], u[2] - v[2]);
    }

    public static vec3 operator *(vec3 v, double t)
    {
        return new vec3(v[0] * t, v[1] * t, v[2] * t);
    }

    public static vec3 operator *(double t, vec3 v)
    {
        return v * t; 
    }
    
    public static vec3 operator *(vec3 v1, vec3 v2)
    {
        return new vec3(v1[0]*v2[0], v1[1]*v2[1], v1[2]*v2[2]);
    }

    public static vec3 operator /(vec3 v, double t)
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

    public double dot(vec3 v1, vec3 v2)
    {
        return v1[0]*v2[0]+ v1[1]*v2[1]+ v1[2]*v2[2];
    }

    public vec3 cross(vec3 v1, vec3 v2)
    {
        return new vec3(v1[1] * v2[2] - v1[2] * v2[1],
                        v1[2] * v2[0] - v1[0] * v2[2],
                        v1[0] * v2[1] - v1[1] * v2[0]);
    }
    public vec3 unit_vector(vec3 v)
    {
        return v/v.length();
    }

}

