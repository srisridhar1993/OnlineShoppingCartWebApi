namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BillItems
    {
        public int ID { get; set; }

        public int? BillId { get; set; }

        public int? ProductId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinalAmount { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
