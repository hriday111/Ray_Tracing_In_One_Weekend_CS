using System.ComponentModel;
using Color = Vec3;
using Point3 = Vec3;
public abstract class Material
{
    public virtual bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = new Color(0,0,0);
        scattered = new Ray(attenuation, attenuation);
        return false;
    }
};

public class Lambertian : Material
{
    private Color albedo= new Color();

    public Lambertian(in Color a) { albedo = a;}

    public override bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = albedo;
        var scatter_direction = rec.Normal + attenuation.RandomUnitVector();
        if(scatter_direction.NearZero()) {scatter_direction=rec.Normal;}
        scattered = new Ray(rec.P, scatter_direction);
        return true;
    }
}


public class Metal: Material
{
    private Color albedo= new Color();

    public Metal(in Color a) { albedo = a;}

    public override bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        Vec3 reflected = r_in.Direction.reflect(rec.Normal);
        attenuation = albedo;
        scattered = new Ray(rec.P, reflected);
        return true;
    }
}