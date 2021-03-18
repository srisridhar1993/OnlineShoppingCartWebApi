namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_ProductShipping
    {
        [Key]
        public long ProductShippingId { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public decimal? Depth { get; set; }

        public decimal? Weight { get; set; }

        public decimal? ExtraShippingFees { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public long? ProductId { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual M_Product M_Product { get; set; }
    }
}
