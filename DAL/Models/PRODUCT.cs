namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTS")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            PURCHASE_PRODUCTS = new HashSet<PURCHASE_PRODUCTS>();
            SALES_PRODUCTS = new HashSet<SALES_PRODUCTS>();
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string ProductDescription { get; set; }

        public int ProductSearchId { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductUoM { get; set; }

        public int ProductType { get; set; }

        public virtual PRODUCT_CATEGORY_MASTER_NEW PRODUCT_CATEGORY_MASTER { get; set; }

        public virtual UOM_CATEGORY_MASTER UOM_CATEGORY_MASTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_PRODUCTS> PURCHASE_PRODUCTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALES_PRODUCTS> SALES_PRODUCTS { get; set; }
    }
}
