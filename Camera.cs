using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using Color = Vec3;
using Point3 = Vec3;
/// <summary>
/// A simple camera model for rendering the scene.
/// </summary>
public class Camera
{   

    public double aspect_ratio=1.0;
    public int image_width = 100;
    public  int samples_per_pixel = 10;
    public int max_depth =10;
    int image_height;
    double pixel_samples_scale;
    Point3 camera_center = new Point3();
    Point3 pixel00_loc = new Point3();
    Vec3 pixel_delta_u = new Vec3();
    Vec3 pixel_delta_v = new Vec3();

    public void render(in IHittable world)
    {
        initialize();
        Console.WriteLine($"P3\n"+image_width+" "+image_height+"\n255\n\r");
        for (int j=0; j<image_height; j++)
        {
            Console.Error.Write("\rLines remaining: "+(image_height-j)+" ");
            for(int i=0; i<image_width; i++)
            {
                Color pixel_color = new Color(0,0,0);
                for(int sample = 0; sample < samples_per_pixel; sample++)
                {
                    var r = get_ray(i,j);
                    pixel_color+=RayColor(r,max_depth, world);
                }
                ColorUtils.WriteColor(Console.Out, pixel_samples_scale*pixel_color);
            }
        }

        Console.Error.Write("\rDone.                         \n");
    }

    Vec3 sample_square()
    {
        return new Vec3(RTHelpers.RandomDouble()-0.5, RTHelpers.RandomDouble()-0.5,0);
    }
    Ray get_ray(int i, int j)
    {
        var offset = sample_square();
        var pixel_sample = pixel00_loc 
                            + ((i+offset.x) * pixel_delta_u)
                            + ((j+offset.y) * pixel_delta_v);
        var RayOrigin = camera_center;
        var RayDirection = pixel_sample - RayOrigin;

        return new Ray(RayOrigin, RayDirection);
    }
    void initialize()
    {
        image_height=(int)(image_width/aspect_ratio);
        image_height = (image_height<1)? 1: image_height;
        pixel_samples_scale = 1.0 / samples_per_pixel;
        camera_center = new Point3(0,0,0);
        var focal_length = 1.0;
        var viewport_height = 2.0;
        var viewport_width = viewport_height * ((double)image_width)/image_height;
        //Vectors accros Horz and Vert viewport edges
        var viewport_u = new Vec3(viewport_width, 0, 0);
        var viewport_v = new Vec3(0, -viewport_height, 0);

        // Horizontal and Vertical Delta Vectors from pixel to pixel
        pixel_delta_u = viewport_u / image_width;
        pixel_delta_v = viewport_v / image_height;

        var viewport_upper_left = camera_center 
                                - new Vec3(0,0,focal_length) - viewport_u/2 - viewport_v/2;
        pixel00_loc = viewport_upper_left + 0.5* (pixel_delta_u+pixel_delta_v);

    }
    Color RayColor(in Ray r, int depth, in IHittable world)
    {
        if(depth<=0) {return new Color(0,0,0);}
        HitRecord rec;


        if(world.Hit(r, new Interval(0.001, RTHelpers.Infinity), out rec))
        {
            Ray scattered= new Ray();
            Color attenuation = new Color(0,0,0);
            if(rec.mat.scatter(r, rec, out attenuation, out scattered))
            {
                return attenuation* RayColor(scattered,depth-1, world);
            }
            return new Color(0,0,0);
        }

        Vec3 unit_dir= r.Direction.unit_vector();
        var a = 0.5*(unit_dir.y+1.0);
        return (1.0-a)*new Color(1.0,1.0,1.0) + a*new Color(0.5,0.7,1.0);

    }
}
