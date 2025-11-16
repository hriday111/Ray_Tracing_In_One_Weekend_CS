using System.IO;
using System.Numerics;
using Color = vec3;
public static class Program
{
    public static void Main(string[] args)
    {
        int image_width = 256;
        int image_height = 256;
        Console.WriteLine($"P3\n"+image_width+" "+image_height+"\n255\n\r");
        for (int j=0; j<image_height; j++)
        {
            Console.Error.Write("\rLines remaining: "+(image_height-j)+" ");
            for(int i=0; i<image_width; i++)
            {
                var pixel_color = new Color(((double)i)/(image_width-1), ((double)j)/(image_height-1), 0);
                ColorUtils.WriteColor(Console.Out, pixel_color);
            }
        }

        Console.Error.Write("\rDone.                         \n");
        
    }
    
}