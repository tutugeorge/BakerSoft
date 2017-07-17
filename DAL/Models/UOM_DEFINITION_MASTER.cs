namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UOM_DEFINITION_MASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UOM_DEFINITION_MASTER()
        {
            SALES_PRODUCTS = new HashSet<SALES_PRODUCTS>();
        }

        [Key]
        public int UoMId { get; set; }

        [Required]
        [StringLength(50)]
        public string UoMCode { get; set; }

        [StringLength(300)]
        public string UoMDescription { get; set; }

        public int UoMCategoryId { get; set; }

        public decimal UoMConversionFactor { get; set; }

        public virtual UOM_CATEGORY_MASTER UOM_CATEGORY_MASTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALES_PRODUCTS> SALES_PRODUCTS { get; set; }
    }
}
