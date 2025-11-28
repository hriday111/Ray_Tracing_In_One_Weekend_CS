using System.Drawing;
using Color = Vec3;
using Point3 = Vec3;
public class Camera
{   

    public double aspect_ratio=1.0;
    public int image_width = 100;
    int image_height;
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
                var pixel_center = pixel00_loc + (i * pixel_delta_u) + (j* pixel_delta_v);
                var ray_direction = pixel_center - camera_center;
                var r = new Ray(camera_center, ray_direction);
                var pixel_color = r.RayColor(world);
                ColorUtils.WriteColor(Console.Out, pixel_color);
            }
        }

        Console.Error.Write("\rDone.                         \n");
    }

    void initialize()
    {
        image_height=(int)(image_width/aspect_ratio);
        image_height = (image_height<1)? 1: image_height;
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
    Color RayColor(in Ray r, in IHittable world)
    {
        HitRecord rec;
        if(world.Hit(r, new Interval(0, RTHelpers.Infinity), out rec))
        {
            return 0.5 * (rec.Normal+new Color(1,1,1));
        }

        Vec3 unit_dir= r.Direction.unit_vector();
        var a = 0.5*(unit_dir[1]+1.0);
        return (1.0-a)*new Color(1.0,1.0,1.0) + a*new Color(0.5,0.7,1.0);

    }
}