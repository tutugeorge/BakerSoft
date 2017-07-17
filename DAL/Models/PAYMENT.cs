namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYMENTS")]
    public partial class PAYMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYMENT()
        {
            PAYMENT_ATTRIBUTES = new HashSet<PAYMENT_ATTRIBUTES>();
            PURCHASE_PAYMENTS = new HashSet<PURCHASE_PAYMENTS>();
            SALES_PAYMENTS = new HashSet<SALES_PAYMENTS>();
        }

        public int PaymentId { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int PaymentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT_ATTRIBUTES> PAYMENT_ATTRIBUTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_PAYMENTS> PURCHASE_PAYMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALES_PAYMENTS> SALES_PAYMENTS { get; set; }
    }
}
