namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATEGORY_TAX_DEFINITION_NEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY_TAX_DEFINITION_NEW()
        {
            PRODUCT_CATEGORY_MASTER_NEW = new HashSet<PRODUCT_CATEGORY_MASTER_NEW>();
        }

        [Key]
        public int SequenceId { get; set; }

        public int TaxId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_CATEGORY_MASTER_NEW> PRODUCT_CATEGORY_MASTER_NEW { get; set; }

        public virtual TAX_MASTER TAX_MASTER { get; set; }
    }
}
