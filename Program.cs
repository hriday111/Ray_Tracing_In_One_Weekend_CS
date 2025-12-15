using System.IO;
using System.Numerics;
using System.Reflection.Metadata;
using Color = Vec3;
using Point3 = Vec3;
public static class Program
{

    
    
    public static void Main(string[] args)
    {
        HittableList world = new HittableList();
        world.Add(new Sphere(new Point3(0, -100.5, -1), 100));
        world.Add(new Sphere(new Point3(0, 0, -1), 0.5));

        Camera cam = new Camera();

        cam.aspect_ratio = 16.0/9.0;
        cam.image_width = 400;
        cam.samples_per_pixel = 100;
        cam.render(world);
    }
    
}