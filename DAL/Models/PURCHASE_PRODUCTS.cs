namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PURCHASE_PRODUCTS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal PurchasePrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual PURCHASE_TRANSACTIONS PURCHASE_TRANSACTIONS { get; set; }
    }
}
