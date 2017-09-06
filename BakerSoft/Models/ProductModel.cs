using BakerSoft.Definitions;
using BakerSoft.Models;
using BakerSoft.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class ProductModel
    {
        private IProductRepository _productRepository;

        public ProductModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> RetreiveAllProducts()
        {
            return _productRepository.RetreiveAllProducts();
        }

        public List<Product> SearchByName(string name)
        {
            return _productRepository.GetProductsByName(name);
        }

        public List<Product> SearchById(string id)
        {
            return _productRepository.GetProductsById(id);
        }

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public void Add(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public List<ProductCategory> GetProductCategories()
        {
           return _productRepository.GetTaxMaster();
        }

        public List<UomCategory> GetUoMCategories()
        {
            return _productRepository.GetUomCategories();
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}
