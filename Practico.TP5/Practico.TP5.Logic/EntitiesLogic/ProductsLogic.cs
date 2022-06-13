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
        public List<Products> GetProductsWithoutStock()
        {
            var queryProductWithoutStock = _context.Products.Where(prod => prod.UnitsInStock == 0);
            return queryProductWithoutStock.ToList();
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

        #region Exercise 9
        public List<Products> GetProductsOrderByName()
        {
            var queryGetProductsOrderByName = from products in _context.Products
                                              orderby products.ProductName
                                              select products;

            return queryGetProductsOrderByName.ToList();
        }
        #endregion

        #region Exercise 10
        public List<Products> GetProductsOrderByUnitStockDesc()
        {
            return _context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }
        #endregion

        #region Exercise 11
        public List<string> GetDistincCategoriesProducts()
        {
            var queryDistincCatsProducts = from products in _context.Products
                                           join categories in _context.Categories
                                           on products.CategoryID equals categories.CategoryID
                                           group products by new
                                           {
                                               products.CategoryID,
                                               categories.CategoryName
                                           }
                                           into productsCategories
                                           select productsCategories.Key.CategoryName;

            return queryDistincCatsProducts.ToList();
        }
        #endregion

        #region Exercise 12
        public Products GetFirstProductList()
        {
            return _context.Products.First();
        }
        #endregion
    }
}
