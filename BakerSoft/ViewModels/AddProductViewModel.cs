using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        private ProductModel _productModel;

        public string ProductSearchId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string SellingPrice { get; set;}
        public Tax ProductTax { get; set; }
        public List<Price> PriceList { get; set; }
        private List<Tax> _taxRateList;
        public List<Tax> TaxRateList
        {
            get
            {
                if(_taxRateList == null)
                {
                    _taxRateList = new List<Tax>()
                    {
                        new Tax() { CGST = 0.05, SGST = 0.05 },
                        new Tax() { CGST = 0.06, SGST = 0.06 },
                        new Tax() { CGST = 0.09, SGST = 0.09 }
                    };
                }
                return _taxRateList;
            }
            set
            {
                SetProperty(ref _taxRateList, value);
            }
        }
        private List<UOM> _uomList;
        public List<UOM> UOMList
        {
            get
            {
                if (_uomList == null)
                {
                    _uomList = new List<UOM>()
                    {
                        new UOM() { Id =1, Name = "Packet" },
                        new UOM() { Id =2, Name = "Piece" },
                        new UOM() { Id =3, Name = "Gram" },
                        new UOM() { Id =4, Name = "Litre" }
                    };
                }
                return _uomList;
            }
            set
            {
                SetProperty(ref _uomList, value);                
            }
        }

        //Add other data capture items for product
        public DelegateCommand AddProductCmd { get; set; }

        public AddProductViewModel(ProductModel productModel)
        {
            _productModel = productModel;
            AddProductCmd = new DelegateCommand(AddProduct);

            
        }

        private void AddProduct()
        {
            var product = new Product();
            product.Name = ProductName;
            product.SearchId = Convert.ToInt32(ProductSearchId);
             
            _productModel.Add(product);
        }
    }
}
