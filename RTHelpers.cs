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

    private static System.Threading.ThreadLocal<Random> _localRandom = 
            new System.Threading.ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

        
    public static double RandomDouble()
    {
        // Use the instance from the current thread's local storage
        //return _localRandom.Value.NextDouble();
        if (_localRandom.Value == null)
            throw new InvalidOperationException("Random instance is not initialized.");
        return _localRandom.Value.NextDouble();
    }

    public static double RandomDouble(double min, double max)
    {
        return min + (max - min) * RandomDouble();
    }
}