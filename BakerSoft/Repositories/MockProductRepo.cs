using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;
using BakerSoft.Models;

namespace BakerSoft.Repositories
{
    class MockProductRepo : IProductRepository
    {
        List<Product> products = new List<Product>()
            {
                //new Product() { ProductId=1001, ProductName="P1", ProductDescription="P1DEsc" , ProductUoM=1, ProductSearchId=1001,
                //    ProductTax = new Tax() { CGST = 0.05, SGST = 0.05},
                //    PriceList = new List<Price>() { new Price() { PurchaseId = 1, PurchasePrice = 100.00, SellingPrice = 120.00 } } },
                //new Product() { ProductId=1002, ProductName="P2", ProductDescription="P2DEsc" , ProductUoM=2, ProductSearchId=1002,
                //    ProductTax = new Tax() { CGST = 0.10, SGST = 0.10},
                //    PriceList = new List<Price>() { new Price() { PurchaseId = 1, PurchasePrice = 100.00, SellingPrice = 120.00 } } },
            };

        public void AddProduct(Product product)
        {
            product.ProductTax.CGST = 0.09;
            product.ProductTax.SGST = 0.09;
            products.Add(product);
        }

        public List<Product> GetProductsById(string id)
        {
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetTaxMaster()
        {
            throw new NotImplementedException();
        }

        public List<UomCategory> GetUomCategories()
        {
            throw new NotImplementedException();
        }
    }
}
