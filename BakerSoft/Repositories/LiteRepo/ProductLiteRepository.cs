using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakerSoft.Models;
using GSTBill.Models;
using DAL.LiteDB;
using AutoMapper;
using DAL.Models;

namespace BakerSoft.Repositories
{
    class ProductLiteRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            using (var db = new StoreDbContext())
            {
                PRODUCT prod = Mapper.Map<PRODUCT>(product);
                prod.ProductCategoryId = 1;
                prod.ProductType = 1;
                //prod.ProductUoM = 1;

                db.Set<PRODUCT>().Add(prod);
                db.SaveChanges();
            }
        }

        public List<Product> GetProductsById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetTaxMaster()
        {
            List<ProductCategory> categories = new List<ProductCategory>();
            using (var db = new StoreDbContext())
            {
                var query = (from a in db.Set<PRODUCT_CATEGORY_MASTER_NEW>()
                             select a);
                categories = Mapper.Map<List<ProductCategory>>(query.ToList());
                //var c = query.ToList();
            }
            return categories;
        }

        public List<UomCategory> GetUomCategories()
        {
            List<UomCategory> categories = new List<UomCategory>();
            using (var db = new StoreDbContext())
            {
                var query = (from a in db.Set<UOM_CATEGORY_MASTER>()
                             select a);
                categories = Mapper.Map<List<UomCategory>>(query.ToList());
            }
            return categories;
        }
    }
}
