using System.ComponentModel;
using Color = Vec3;
using Point3 = Vec3;
public interface IMaterial
{
    public virtual bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = new Color(0,0,0);
        scattered = new Ray(attenuation, attenuation);
        return false;
    }
};

public class Lambertian : IMaterial
{
    private Color albedo= new Color();

    public Lambertian(in Color a) { albedo = a;}

    public  bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = albedo;
        var scatter_direction = rec.Normal + attenuation.RandomUnitVector();
        if(scatter_direction.NearZero()) {scatter_direction=rec.Normal;}
        scattered = new Ray(rec.P, scatter_direction);
        return true;
    }
}


public class Metal: IMaterial
{
    private Color albedo= new Color();
    private double fuzz;
    public Metal(in Color a, double fuzz) { albedo = a; this.fuzz = fuzz;}

    public bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        Vec3 reflected = r_in.Direction.reflect(rec.Normal);
        reflected = reflected.unit_vector() + (fuzz* albedo.RandomUnitVector());
        attenuation = albedo;
        scattered = new Ray(rec.P, reflected);
        return scattered.Direction.dot(rec.Normal)>0;
    }
}


public class Dielectric: IMaterial
{
    double refraction_index;
    static double reflectance(double cos, double ri)
    {
        var r0 = (1-ri)/(1+ri);
        r0=r0*r0;
        return r0 + (1-r0)*Math.Pow((1-cos), 5);
    }

    
    public Dielectric(double ref_idx) { refraction_index = ref_idx;}
    public bool scatter(in Ray r_in, in HitRecord rec, out Color attenuation, out Ray scattered)
    {
        attenuation = new Color(1,1,1);
        double ri = rec.FrontFace? (1/refraction_index) : refraction_index;

        Vec3 unit_dir = r_in.Direction.unit_vector();
        double cos_theta = Math.Min(-unit_dir.dot(rec.Normal), 1.0);
        double sin_theta = Math.Sqrt(1- cos_theta*cos_theta);
        Vec3 direction = new Vec3();
        if(ri*sin_theta>1.0 || reflectance(cos_theta, ri)>RTHelpers.RandomDouble())
        
        { 
            direction = unit_dir.reflect(rec.Normal);
        }
        else
        {
            direction = unit_dir.refract(rec.Normal, ri);
        }
        

        scattered = new Ray(rec.P, direction);
        return true;    
    }

}