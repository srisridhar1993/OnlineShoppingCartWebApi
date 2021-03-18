namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_ProductInventory
    {
        [Key]
        public long ProductInventoryId { get; set; }

        public long ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        public int Quantity { get; set; }

        public int? SellQuantity { get; set; }

        public int? AvailableQuantity { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual M_Product M_Product { get; set; }
    }
}
