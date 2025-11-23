
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Point3 = Vec3;
using Color = Vec3;
using System.ComponentModel;
using System.Reflection.Metadata;
public class HittableList : IHittable
{
    public List<IHittable> Objects {get; private set;} = new List<IHittable>();

    public HittableList(){ }

    public HittableList(IHittable obj)
    {
        Add(obj);
    }

    public void Clear()
    {
        Objects.Clear();
    }

    public void Add(IHittable obj)
    {
        Objects.Add(obj);
    }

    public bool Hit(in Ray r, Interval ray_t, out HitRecord rec)
    {
        HitRecord temp_rec = new HitRecord();
        bool hit_anything = false;
        rec = new HitRecord();
        double closest_so_far = ray_t.Max;

        foreach(var obj in Objects)
        {
            if(obj.Hit(in r, new Interval(ray_t.Min, closest_so_far), out temp_rec))
            {
                hit_anything = true;
                closest_so_far = temp_rec.T;
                rec = temp_rec;
            }
        }

        //if(!hit_anything) {  return false;} // just making sure the out is initialized in case ray doesn't hit anything
        return hit_anything;
    }

}