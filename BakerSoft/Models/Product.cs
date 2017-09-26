using BakerSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class Product //: Item
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductSearchId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductUoM { get; set; }
        public int ProductType { get; set; }
        public int Quantity { get; set; }
        private decimal _defaultSellingPrice = 0.00m;
        public decimal DefaultSellingPrice
        {
            get
            {                
                return Convert.ToDecimal(PriceList[0] + 
                    ProductTax.TaxRate * PriceList[0]);
            }
            set
            {
                _defaultSellingPrice = value;
            }
        }
        private string _tax = "0";
        public string Tax
        {
            get
            {
                return Convert.ToString(ProductTax.TaxRate);
            }
            set
            {
                _tax = value;
            }
        }

        //public List<Price> PriceList { get; set; }
        public List<decimal?> PriceList { get; set; }

        public List<ProductPrice> PricesList { get; set; }

        public Tax ProductTax { get; set; }

        public List<UomDefinitions> UoMDefinitionList { get; set; }
    }

    public class ProductPrice
    {
        public decimal PurchasePrice { get; set; }
        public decimal? SellingPrice { get; set; }
    }
}
