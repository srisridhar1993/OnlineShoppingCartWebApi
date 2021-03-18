namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_PaymentDetails
    {
        [Key]
        public long PaymentId { get; set; }

        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public decimal Amount { get; set; }

        public decimal? CGST { get; set; }

        public decimal? SGST { get; set; }

        public decimal? OtherTax { get; set; }

        public decimal GrandTotal { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentReferenceNo { get; set; }

        public int PaymentTypeId { get; set; }

        [StringLength(16)]
        public string CardNumber { get; set; }

        [StringLength(3)]
        public string CVVNumber { get; set; }

        [StringLength(150)]
        public string NameOnCard { get; set; }

        [StringLength(150)]
        public string TransactionId { get; set; }

        [StringLength(50)]
        public string TransactionStatus { get; set; }

        [StringLength(12)]
        public string ChecqueNumber { get; set; }

        public decimal? ChecqueAmount { get; set; }

        [StringLength(150)]
        public string DrawnOnBank { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Active { get; set; }

        public virtual M_Customer M_Customer { get; set; }

        public virtual M_PaymentType M_PaymentType { get; set; }

        public virtual T_Order T_Order { get; set; }
    }
}
