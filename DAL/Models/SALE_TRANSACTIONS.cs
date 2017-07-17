namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALE_TRANSACTIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALE_TRANSACTIONS()
        {
            SALES_PRODUCTS = new HashSet<SALES_PRODUCTS>();
            SALES_PAYMENTS = new HashSet<SALES_PAYMENTS>();
        }

        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal TransactionTotal { get; set; }

        public decimal TransactionTaxTotal { get; set; }

        public decimal TransactionDiscountTotal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALES_PRODUCTS> SALES_PRODUCTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALES_PAYMENTS> SALES_PAYMENTS { get; set; }

        public virtual SALE_TRANSACTIONS SALE_TRANSACTIONS1 { get; set; }

        public virtual SALE_TRANSACTIONS SALE_TRANSACTIONS2 { get; set; }
    }
}
