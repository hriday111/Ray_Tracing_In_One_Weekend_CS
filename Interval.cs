using System;
using System.Runtime.CompilerServices;

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
    public double Size()
    {
        return Max - Min;
    }
}