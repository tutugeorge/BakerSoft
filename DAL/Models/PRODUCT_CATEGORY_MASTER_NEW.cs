namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCT_CATEGORY_MASTER_NEW
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string CategoryDescription { get; set; }

        public int CategoryTaxId { get; set; }

        public virtual CATEGORY_TAX_DEFINITION_NEW CATEGORY_TAX_DEFINITION_NEW { get; set; }

        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}
