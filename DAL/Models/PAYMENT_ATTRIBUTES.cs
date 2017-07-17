namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAYMENT_ATTRIBUTES
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string PaymentAttribute { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentAttributeValue { get; set; }

        public virtual PAYMENT PAYMENT { get; set; }
    }
}
