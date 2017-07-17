namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALES_PRODUCTS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleTransactionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UoM { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal SellingPrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual SALE_TRANSACTIONS SALE_TRANSACTIONS { get; set; }

        public virtual UOM_DEFINITION_MASTER UOM_DEFINITION_MASTER { get; set; }
    }
}
