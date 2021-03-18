namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Bill
    {
        [Key]
        public int BillId { get; set; }

        [Column(TypeName = "money")]
        public decimal? BillAmount { get; set; }

        public int? BillType { get; set; }

        [StringLength(50)]
        public string CC_No { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
