using Point3 = Vec3;
using Color = Vec3;

public struct HitRecord
{
    public Point3 P;
    public Vec3 Normal;
    public Material mat;
    public double T; // t is the distance from ray origin


    public bool FrontFace;

    public void SetFaceNormal(in Ray r, in Vec3 outward_normal)
    {
        FrontFace= r.Direction.dot(outward_normal) <0;

        Normal = FrontFace? outward_normal: -outward_normal;
    }
}
public interface IHittable
{
   public  bool Hit(in Ray r,Interval ray_t, out HitRecord rec);
}