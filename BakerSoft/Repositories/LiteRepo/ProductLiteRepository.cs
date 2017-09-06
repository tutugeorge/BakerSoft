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
using BakerSoft.Exceptions;

namespace BakerSoft.Repositories
{
    class ProductLiteRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            using (var db = new StoreDbContext())
            {
                PRODUCT prod = Mapper.Map<PRODUCT>(product);
                //prod.ProductCategoryId = 1;
                prod.ProductType = 1;
                //prod.ProductUoM = 1;

                db.Set<PRODUCT>().Add(prod);
                db.SaveChanges();
            }
        }

        public Product GetProductDetails(int id)
        {
            Product product = null;
            using (var db = new StoreDbContext())
            {
                var query = from b in db.Set<PRODUCT>()
                            where b.ProductSearchId == id
                            select b;
                product = Mapper.Map<Product>(query.FirstOrDefault());
            }
            return product;
        }

        public List<Product> GetProductsById(string id)
        {
            int i = Convert.ToInt32(id);
            List<Product> productList = new List<Product>();
            Product prods;
            using (var db = new StoreDbContext())
            {
                var query = (from b in db.Set<PRODUCT>()
                             where b.ProductSearchId == i
                             select b);
                var prod = query.ToList();
                prods = Mapper.Map<Product>(query.FirstOrDefault());

                var taxID = (from t in db.Set<PRODUCT_CATEGORY_MASTER_NEW>()
                             where t.CategoryId == prods.ProductCategoryId
                             select t.CATEGORY_TAX_DEFINITION_NEW.TaxId).ToList();
                var tax = (from t in db.Set<TAX_MASTER>()
                           where taxID.Contains(t.TaxId)
                           select t).FirstOrDefault();
                prods.ProductTax = Mapper.Map<Tax>(tax);

                var price = (from p in db.Set<PURCHASE_PRODUCTS>()
                             where p.ProductId == prods.ProductId
                             select p.SellingPrice).ToList();
                if (price.Count <= 0)
                    throw new NoPurchasedProductException();
                prods.PriceList = new List<decimal?>();

                //price.ForEach(x => productList.Add(prods));

                //for (int index = 0; index < price.Count; index++)
                //    productList[index].PriceList.Add(price[index]);
                price.ForEach(x => prods.PriceList.Add((x.Value)));


            }
            return (new List<Product>() { prods });
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

        public List<Product> RetreiveAllProducts()
        {
            List<Product> products;
            using (var db = new StoreDbContext())
            {
                var query = (from a in db.Set<PRODUCT>()
                             select a);
                products = Mapper.Map<List<Product>>(query.ToList());                
            }
            return products;
        }
    }
}
