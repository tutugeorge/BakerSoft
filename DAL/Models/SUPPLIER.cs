namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUPPLIERS")]
    public partial class SUPPLIER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPPLIER()
        {
            PURCHASE_TRANSACTIONS = new HashSet<PURCHASE_TRANSACTIONS>();
        }

        public int SupplierId { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        public int SupplierAddressId { get; set; }

        [StringLength(100)]
        public string SupplierTIN { get; set; }

        [StringLength(100)]
        public string SupplierGST { get; set; }

        public virtual ADDRESS ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_TRANSACTIONS> PURCHASE_TRANSACTIONS { get; set; }
    }
}
