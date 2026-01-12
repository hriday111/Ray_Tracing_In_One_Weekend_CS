using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Numerics;

public static class ColorUtils
{
    
    public static void WriteColor(TextWriter outStream, Vec3 pixel_color)
    {
        var r = linear_to_gamma(pixel_color.x);
        var g = linear_to_gamma(pixel_color.y);
        var b = linear_to_gamma(pixel_color.z);

        Interval intensity = new Interval(0.000,0.999);
        int rbyte = (int) (256*intensity.Clamp(r)); // the 255.999 is used instead of 
        int gbyte = (int) (256*intensity.Clamp(g));  // 255 to avoid and flp error that might cause 255 to be never reached
        int bbyte = (int) (256*intensity.Clamp(b)); 

        outStream.WriteLine(rbyte+" "+gbyte+" "+bbyte);
    }


    public static double linear_to_gamma(double linear_component)
    {
        if(linear_component>0) return Math.Sqrt(linear_component);

        return 0;
    }
}

