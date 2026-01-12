
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;
using Color = Vec3;
using Point3 = Vec3;
/// <summary>
/// Main program to set up the scene and render the image.
/// </summary>
public static class Program
{

    
    
    public static void Main(string[] args)
    {
        HittableList world = new HittableList();

        var MatGround = new Lambertian(new Color(0.8,0.8,0.8));
        var MatCenter = new Lambertian(new Color(0.1,0.2,0.5));
        var MatLeft = new Dielectric(1.5);
        //var MatBubble = new Dielectric(1/1.5);
        var MatRight = new Metal(new Color(0.8,0.6,0.2), 1.0);
        world.Add(new Sphere(new Point3(0, -100.5, -1), 100.0, MatGround));
        world.Add(new Sphere(new Point3(0, 0, -1.2), 0.5, MatCenter));
        world.Add(new Sphere(new Point3(-1, 0, -1), 0.5, MatLeft));
        //world.Add(new Sphere(new Point3(-1, 0, -1), 0.4, MatBubble));
        world.Add(new Sphere(new Point3(1, 0, -1), 0.5, MatRight));

        Camera cam = new Camera();

        cam.aspect_ratio = 16.0/9.0;
        cam.image_width = 1080;
        cam.samples_per_pixel = 100;
        cam.max_depth=50;
        cam.render(world);
    }
    
}