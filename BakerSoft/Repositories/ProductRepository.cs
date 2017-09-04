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
            Product prods;
            using (var db = new StoreDB())
            {
                var query = (from b in db.PRODUCTS
                             where b.ProductId == i
                             select b);
                var prod =query.ToList();
                //List<Product> prods = Mapper.Map<List<Product>>(query.ToList());
                prods = Mapper.Map<Product>(query.FirstOrDefault());

                var price = (from p in db.PURCHASE_PRODUCTS
                             where p.ProductId == i
                             select p.SellingPrice).ToList();

                //price.
                prods.PriceList = new List<decimal?>();
                price.ForEach(x=> prods.PriceList.Add((x.Value)));

                var taxID = (from t in db.PRODUCT_CATEGORY_MASTER_NEW
                             where t.CategoryId == prods.ProductCategoryId
                           select t.CATEGORY_TAX_DEFINITION_NEW.TaxId).ToList();
                var tax = (from t in db.TAX_MASTER
                           where taxID.Contains(t.TaxId)
                           select t).FirstOrDefault();

                prods.ProductTax = Mapper.Map<Tax>(tax);
            }
            return (new List<Product>() { prods});
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

        public List<Product> RetreiveAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
