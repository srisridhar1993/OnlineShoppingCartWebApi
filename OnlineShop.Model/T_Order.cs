namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Order()
        {
            T_OrderDetails = new HashSet<T_OrderDetails>();
            T_PaymentDetails = new HashSet<T_PaymentDetails>();
            T_StatusHistory = new HashSet<T_StatusHistory>();
        }

        [Key]
        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public int? StatusId { get; set; }

        public long? ShippingAddressId { get; set; }

        public long? BillingAddressId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? PaymentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        public virtual M_BillingAddress M_BillingAddress { get; set; }

        public virtual M_Customer M_Customer { get; set; }

        public virtual M_PaymentType M_PaymentType { get; set; }

        public virtual M_ShippingAddress M_ShippingAddress { get; set; }

        public virtual M_Status M_Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_OrderDetails> T_OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_PaymentDetails> T_PaymentDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_StatusHistory> T_StatusHistory { get; set; }
    }
}
