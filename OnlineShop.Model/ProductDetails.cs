using System;
using System.Collections.Generic;

namespace OnlineShop.Model
{
    public class ProductDetails
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Tags { get; set; }
        public string DefaultImage { get; set; }
        public string Description { get; set; }
        public bool? InStock { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<M_ProductImage> ProductImage { get; set; }
        public int Quantity { get; set; }
        public long? ProductInventoryId { get; set; }
        public int? SellQuantity { get; set; }
        public string SKU { get; set; }
        public int? AvailableQuantity { get; set; }
        public long? ProductPriceId { get; set; }
        public decimal? TaxExcludedPrice { get; set; }
        public decimal? TaxIncludedPrice { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? ComparedPrice { get; set; }
        public decimal? Length { get; set; }
        public decimal? ExtraShippingFees { get; set; }
        public long? ProductShippingId { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public string Color { get; set; }
        public decimal? Weight { get; set; }
        public int RowNumber { get; set; }
    }
}
