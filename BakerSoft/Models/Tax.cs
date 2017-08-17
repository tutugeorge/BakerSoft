using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class TaxMaster
    {
        public int TaxId { get; set; }

        public string TaxDescription { get; set; }

        public string TaxChar { get; set; }

        public decimal TaxRate { get; set; }
    }

    class ProductCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public int TaxId { get; set; }

        public decimal TaxRate { get; set; }
    }

    class TaxCategory
    {
        public int CategoryId { get; set; }

        public int TaxId { get; set; }

        public string Description { get; set; }
    }

    class Tax
    {
        public int TaxId { get; set; }
        public double SGST { get; set; }
        public double CGST { get; set; }
        public double TaxTotal
        {
            get
            {
                return (SGST + CGST);
            }
        }            
    }
}
