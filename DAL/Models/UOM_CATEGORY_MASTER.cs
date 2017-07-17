namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UOM_CATEGORY_MASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UOM_CATEGORY_MASTER()
        {
            PRODUCTS = new HashSet<PRODUCT>();
        }

        [Key]
        public int UoMCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string UoMCategoryCode { get; set; }

        [StringLength(300)]
        public string UoMCategoryDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }

        public virtual UOM_DEFINITION_MASTER UOM_DEFINITION_MASTER { get; set; }
    }
}
