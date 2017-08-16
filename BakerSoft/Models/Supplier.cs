using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class Supplier
    {
        public string SupplierId { get; set; }
        public string SupplierGST { get; set; }
        public string SupplierName { get; set; }
        public Address ADDRESS { get; set; }
    }
}
