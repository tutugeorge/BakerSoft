using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class UOM
    {
        public string Name { get; set; }
        public int Id  { get; set; }
    }
    class UomCategory
    {
        public int UoMCategoryId { get; set; }

        public string UoMCategoryCode { get; set; }

        public string UoMCategoryDescription { get; set; }
    }

    class UomDefinitions
    {
        public int UoMId { get; set; }
        
        public string UoMCode { get; set; }
        
        public string UoMDescription { get; set; }

        public int UoMCategoryId { get; set; }

        public decimal UoMConversionFactor { get; set; }
    }
}
