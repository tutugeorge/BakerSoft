using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;
using DAL.Models;
using AutoMapper;
namespace BakerSoft.Repositories
{
    class ProductRepository : IProductRepository
    {        
        public void AddProduct(Product product)
        {
            using (var db = new StoreDB())
            {
                PRODUCT prod = Mapper.Map<PRODUCT>(product);
                prod.ProductCategoryId = 1;
                prod.ProductType = 1;
                prod.ProductUoM = 1;

                db.PRODUCTS.Add(prod);
                db.SaveChanges();
            }
        }

        public List<Product> GetProductsById(string id)
        {
            using (var db = new StoreDB())
            {
                var query = (from b in db.PRODUCTS
                             where b.ProductId == Convert.ToInt16(id)
                             select b);
                List<Product> prods = Mapper.Map<List<Product>>(query.ToList());
                return prods;
            }
        }

        public List<Product> GetProductsByName(string name)
        {
            using (var db = new StoreDB())
            {
                var query = (from b in db.PRODUCTS
                             where b.ProductName.Contains(name)
                             select b);
                List<Product> prods = Mapper.Map<List<Product>>(query.ToList());
                return prods;
            }
        }
    }
}
