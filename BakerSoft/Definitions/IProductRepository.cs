using BakerSoft.Models;
using GSTBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Definitions
{
    interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetProductsById(string id);
        List<Product> GetProductsByName(string name);
        List<ProductCategory> GetTaxMaster();
        List<UomCategory> GetUomCategories();
    }
}
