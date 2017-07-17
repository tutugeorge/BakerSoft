namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADDRESS")]
    public partial class ADDRESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADDRESS()
        {
            SUPPLIERS = new HashSet<SUPPLIER>();
        }

        public int AddressId { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(200)]
        public string AddressLine3 { get; set; }

        [Required]
        [StringLength(200)]
        public string City { get; set; }

        [Required]
        [StringLength(200)]
        public string State { get; set; }

        [StringLength(50)]
        public string Pincode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLIER> SUPPLIERS { get; set; }
    }
}
