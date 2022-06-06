using LabDemo.EF.Data;
using LabDemo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDemo.EF.Logic
{
    public class ProductLogic : BaseLogic, IABMLogic<Products>
    {
        public void Add(Products newProduct)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productEncontrado = context.Products.Find(id);
            context.Products.Remove(productEncontrado);
            context.SaveChanges();
        }

        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public void Update(Products product)
        {
            var productEncontrado = context.Region.Find(product.ProductID);
            productEncontrado.RegionDescription = product.ProductName;
            context.SaveChanges();
        }
    }
}
