using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practico.TP5.Entities;

namespace Practico.TP5.Logic
{
    public class ProductsLogic: BaseLogic
    {
        #region Exercise 2

        public IQueryable<Products> GetProductsWithoutStock()
        {
            var queryProductWithoutStock = _context.Products.Where(prod => prod.UnitsInStock == 0);
            return queryProductWithoutStock;
        }
        #endregion

        #region Exercise 3

        public IQueryable<Products> GetProductsWithMoreThanTreeUnits()
        {
            var queryProductWitMoreTreeUnits = from products in _context.Products
                                               where products.UnitsInStock != 0
                                               && products.UnitPrice > 3
                                               select products;

            return queryProductWitMoreTreeUnits;
        }
        #endregion

        #region Exercise 5

        public Products GetFirstElement(int id = 789)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }
        #endregion
    }
}
