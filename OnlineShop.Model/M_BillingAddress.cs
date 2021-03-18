namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_BillingAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_BillingAddress()
        {
            T_Order = new HashSet<T_Order>();
        }

        [Key]
        public long BillingAddressId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public long? CustomerId { get; set; }

        [Required]
        [StringLength(150)]
        public string Address1 { get; set; }

        [StringLength(150)]
        public string Address2 { get; set; }

        [StringLength(150)]
        public string LandMark { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNo { get; set; }

        [StringLength(6)]
        public string Pincode { get; set; }

        public int? StateId { get; set; }

        public int? CountryId { get; set; }

        [StringLength(150)]
        public string Latitude { get; set; }

        [StringLength(150)]
        public string Longitude { get; set; }

        public bool? Active { get; set; }
        public string AddressType { get; set; }
        public bool? IsDefault { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public virtual M_Customer M_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Order> T_Order { get; set; }
    }
}
