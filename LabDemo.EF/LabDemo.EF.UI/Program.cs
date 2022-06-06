using LabDemo.EF.Entities;
using LabDemo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDemo.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductLogic productLogic = new ProductLogic();

            //foreach(var product in productLogic.GetAll())
            //{
            //    Console.WriteLine($"{product.ProductName} - { product.UnitPrice}");
            //}

            RegionLogic regionLogic = new RegionLogic();
            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
            }

            //regionLogic.Add(new Region
            //{
            //    RegionID = 10,
            //    RegionDescription = "Sarasa"
            //});

            //regionLogic.Delete(10);
            regionLogic.Update(new Region
            {
                RegionDescription = "Una nueva descripción",
                RegionID = 10
            });
            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
            }

            Console.ReadLine();
        }
    }
}
