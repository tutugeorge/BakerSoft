using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;
using DAL.Models;
using AutoMapper;
using BakerSoft.Models;

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
                //prod.ProductUoM = 1;

                db.PRODUCTS.Add(prod);
                db.SaveChanges();
            }
        }

        public List<Product> GetProductsById(string id)
        {
            int i = Convert.ToInt32(id);
            using (var db = new StoreDB())
            {
                var query = (from b in db.PRODUCTS
                             where b.ProductId == i
                             select b);
                var prod =query.ToList();
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

        public List<ProductCategory> GetTaxMaster()
        {
            List<ProductCategory> categories = new List<ProductCategory>();
            using (var db = new StoreDB())
            {
                var query = (from a in db.PRODUCT_CATEGORY_MASTER_NEW
                            select a);
                categories = Mapper.Map<List<ProductCategory>>(query.ToList());
            }
            return categories;
        }

        public List<UomCategory> GetUomCategories()
        {
            List<UomCategory> categories = new List<UomCategory>();
            using (var db = new StoreDB())
            {
                var query = (from a in db.UOM_CATEGORY_MASTER
                             select a);
                categories = Mapper.Map<List<UomCategory>>(query.ToList());
            }
            return categories;
        }
    }
}
