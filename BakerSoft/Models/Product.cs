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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SearchId { get; set; }
        public int CategoryId { get; set; }
        public int UoM { get; set; }
        public int Type { get; set; }
        public int Quantity { get; set; }
        private double _defaultSellingPrice = 0.00;
        public double DefaultSellingPrice
        {
            get
            {
                if (_defaultSellingPrice.Equals(0.00))
                    _defaultSellingPrice = Quantity * PriceList[0].SellingPrice;
                return _defaultSellingPrice;
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
                if (_tax.Equals("0"))
                    _tax = (ProductTax.CGST + ProductTax.SGST).ToString("F2");
                return _tax;
            }
            set
            {
                _tax = value;
            }
        }

        public List<Price> PriceList { get; set; }

        public Tax ProductTax { get; set; }
    }
}
