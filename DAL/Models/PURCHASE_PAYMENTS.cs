namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PURCHASE_PAYMENTS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal PaymentAmount { get; set; }

        public virtual PAYMENT PAYMENT { get; set; }

        public virtual PURCHASE_TRANSACTIONS PURCHASE_TRANSACTIONS { get; set; }
    }
}
