using BakerSoft.Definitions;
using BakerSoft.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class Products
    {
        private IProductRepository _productRepository;

        public Products(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<SaleItem> SearchByName(string name)
        {
            return _productRepository.GetProductsByName(name);
        }

        public List<SaleItem> SearchById(string id)
        {
            return _productRepository.GetProductsById(id);
        }

        public void Add()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}
