namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATEGORY_TAX_DEFINITION
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SequenceId { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public virtual PRODUCT_CATEGORY_MASTER PRODUCT_CATEGORY_MASTER { get; set; }

        public virtual TAX_MASTER TAX_MASTER { get; set; }
    }
}
