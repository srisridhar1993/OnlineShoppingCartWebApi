namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_ProductPrice
    {
        [Key]
        public long ProductPriceId { get; set; }

        public decimal TaxExcludedPrice { get; set; }

        public decimal? TaxIncludedPrice { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? ComparedPrice { get; set; }

        public long ProductId { get; set; }

        public bool? Active { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual M_Product M_Product { get; set; }
    }
}
