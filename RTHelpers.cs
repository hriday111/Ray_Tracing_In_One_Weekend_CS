using System;
using System.Runtime.CompilerServices;

public static class RTHelpers
{
    public const double Infinity = double.PositiveInfinity;

    public const double Pi = Math.PI;

    public static double DegreesToRadians(double deg)
    {
        return deg * Pi /180.0;
    }
}