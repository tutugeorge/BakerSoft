namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TAX_MASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAX_MASTER()
        {
            CATEGORY_TAX_DEFINITION = new HashSet<CATEGORY_TAX_DEFINITION>();
        }

        [Key]
        public int TaxId { get; set; }

        [Required]
        [StringLength(100)]
        public string TaxDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string TaxChar { get; set; }

        public decimal TaxRate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORY_TAX_DEFINITION> CATEGORY_TAX_DEFINITION { get; set; }
    }
}
