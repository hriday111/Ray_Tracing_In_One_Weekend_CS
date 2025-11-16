using System.IO;
using System.Numerics;

public static class ColorUtils
{
    
    public static void WriteColor(TextWriter outStream, Vec3 pixel_color)
    {
        var r = pixel_color[0];
        var g = pixel_color[1];
        var b = pixel_color[2];

        int rbyte = (int) (255.999 *r); // the 255.999 is used instead of 
        int gbyte = (int) (255.999 *g);  // 255 to avoid and flp error that might cause 255 to be never reached
        int bbyte = (int) (255.999 *b); 

        outStream.WriteLine(rbyte+" "+gbyte+" "+bbyte);
    }
}

