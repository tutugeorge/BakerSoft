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
        void AddProduct();
        List<Product> GetProductsById(string id);
        List<Product> GetProductsByName(string name);
    }
}
