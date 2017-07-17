namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PURCHASE_TRANSACTIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PURCHASE_TRANSACTIONS()
        {
            PURCHASE_PRODUCTS = new HashSet<PURCHASE_PRODUCTS>();
            PURCHASE_PAYMENTS = new HashSet<PURCHASE_PAYMENTS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchseId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchaseTxnTotal { get; set; }

        public decimal PurchaseTaxTotal { get; set; }

        public int SupplierId { get; set; }

        public virtual SUPPLIER SUPPLIER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_PRODUCTS> PURCHASE_PRODUCTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_PAYMENTS> PURCHASE_PAYMENTS { get; set; }
    }
}
