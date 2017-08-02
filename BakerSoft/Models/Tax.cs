using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
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
