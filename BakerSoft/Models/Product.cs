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
    }
}
