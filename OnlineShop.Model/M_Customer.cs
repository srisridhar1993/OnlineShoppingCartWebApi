namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_Customer()
        {
            M_BillingAddress = new HashSet<M_BillingAddress>();
            M_ShippingAddress = new HashSet<M_ShippingAddress>();
            T_Order = new HashSet<T_Order>();
            T_PaymentDetails = new HashSet<T_PaymentDetails>();
        }

        [Key]
        public long CustomerId { get; set; }

        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(10)]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }

        public bool? Active { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_BillingAddress> M_BillingAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ShippingAddress> M_ShippingAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Order> T_Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_PaymentDetails> T_PaymentDetails { get; set; }
    }
}
