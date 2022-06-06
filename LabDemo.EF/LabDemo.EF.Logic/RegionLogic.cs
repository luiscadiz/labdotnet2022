using LabDemo.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabDemo.EF.Entities;

namespace LabDemo.EF.Logic
{
    public class RegionLogic : BaseLogic, IABMLogic<Region>
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public void Add(Region newRegion)
        {
            context.Region.Add(newRegion);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            //var regionAEliminar = context.Region.First(r => r.RegionID == Id);
            //regionAEliminar = context.Region.FirstOrDefault(r => r.RegionID == Id);
            //regionAEliminar = context.Region.Single(r => r.RegionID == Id);
            //regionAEliminar = context.Region.SingleOrDefault(r => r.RegionID == Id);
            var regionAEliminar = context.Region.Find(Id);
            context.Region.Remove(regionAEliminar);
            context.SaveChanges();

        }

        public void Update(Region region)
        {
            var regionEncontrada = context.Region.Find(region.RegionID);
            regionEncontrada.RegionDescription = region.RegionDescription;
            context.SaveChanges();
        }
    }
}
