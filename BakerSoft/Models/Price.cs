using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class Price
    {
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseId { get; set; }
    }
}
