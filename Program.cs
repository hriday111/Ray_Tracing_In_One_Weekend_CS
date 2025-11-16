using System;

public static class Program
{
    public static void Main(string[] args)
    {
        int image_width = 256;
        int image_height = 256;
        Console.WriteLine($"P3\n"+image_width+" "+image_height+"\n255\n");
        for (int j=0; j<image_height; j++)
        {
            for(int i=0; i<image_width; i++)
            {
                var r = ((double)i)/ (image_width-1); // 1 is subtracted
                var g = ((double)j)/ (image_height-1);// from both r and g to get a full range from 0.0-1.0 instead of 0.99
                var b = 0.0; 

                int ir = (int) (255.999 *r); // the 255.999 is used instead of 
                int ig = (int) (255.999 *g); // 255 to avoid and flp error that might cause 255 to be never reached
                int ib = (int) (255.999 *b); 

                Console.WriteLine(ir+" "+ig+" "+ib);

            }
        }

        
    }
}