using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;

namespace BakerSoft.Repositories
{
    class MockProductRepo : IProductRepository
    {
        List<Product> products = new List<Product>()
            {
                new Product() { Id=1001, Name="P1", Description="P1DEsc" , UoM=1, SearchId=1001 },
                new Product() { Id=1002, Name="P2", Description="P2DEsc" , UoM=1, SearchId=1002 }
            };

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsById(string id)
        {
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
