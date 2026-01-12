using System;
using System.Runtime.CompilerServices;
/// <summary>
/// A closed interval [Min, Max] with utility methods.
/// </summary>
public readonly struct Interval
{
    public double Min {get;}
    public double Max {get;}

    public static readonly Interval Empty = new Interval (RTHelpers.Infinity, -RTHelpers.Infinity);
    public static readonly Interval Universe = new Interval (-RTHelpers.Infinity, RTHelpers.Infinity)
;
    public Interval() : this(RTHelpers.Infinity, -RTHelpers.Infinity) { }

    public Interval(double min, double max)
    {
        Min=min;
        Max=max;
    }

    public bool Contains(double x)
    {
        return Min <= x && x<= Max;
    }
    public bool Surrounds(double x)
    {
        return Min < x && x < Max;
    }

    public double Clamp(double x)
    {
        if(x<Min) return Min;
        if(x>Max) return Max;
        return x;
    }
    public double Size()
    {
        return Max - Min;
    }
}