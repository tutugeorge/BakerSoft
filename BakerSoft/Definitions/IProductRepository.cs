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
        List<SaleItem> GetProductsById(string id);
        List<SaleItem> GetProductsByName(string name);
    }
}
