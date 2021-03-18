namespace OnlineShop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShopingModel : DbContext
    {
        public OnlineShopingModel()
            : base("name=OnlineShopingModelEntities")
        {
        }

        public virtual DbSet<M_BillingAddress> M_BillingAddress { get; set; }
        public virtual DbSet<M_Category> M_Category { get; set; }
        public virtual DbSet<M_Country> M_Country { get; set; }
        public virtual DbSet<M_Customer> M_Customer { get; set; }
        public virtual DbSet<M_Employee> M_Employee { get; set; }
        public virtual DbSet<M_PaymentType> M_PaymentType { get; set; }
        public virtual DbSet<M_Product> M_Product { get; set; }
        public virtual DbSet<M_ProductImage> M_ProductImage { get; set; }
        public virtual DbSet<M_ProductInventory> M_ProductInventory { get; set; }
        public virtual DbSet<M_ProductPrice> M_ProductPrice { get; set; }
        public virtual DbSet<M_ProductShipping> M_ProductShipping { get; set; }
        public virtual DbSet<M_ShippingAddress> M_ShippingAddress { get; set; }
        public virtual DbSet<M_State> M_State { get; set; }
        public virtual DbSet<M_Status> M_Status { get; set; }
        public virtual DbSet<T_Bill> T_Bill { get; set; }
        public virtual DbSet<T_BillItems> T_BillItems { get; set; }
        public virtual DbSet<T_Order> T_Order { get; set; }
        public virtual DbSet<T_OrderDetails> T_OrderDetails { get; set; }
        public virtual DbSet<T_PaymentDetails> T_PaymentDetails { get; set; }
        public virtual DbSet<T_StatusHistory> T_StatusHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.LandMark)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Pincode)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<M_BillingAddress>()
                .HasMany(e => e.T_Order)
                .WithRequired(e => e.M_BillingAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Country>()
                .Property(e => e.CountryCode)
                .IsUnicode(false);

            modelBuilder.Entity<M_Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Customer>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<M_Customer>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<M_Customer>()
                .HasMany(e => e.T_Order)
                .WithRequired(e => e.M_Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Customer>()
                .HasMany(e => e.T_PaymentDetails)
                .WithRequired(e => e.M_Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<M_Employee>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<M_PaymentType>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<M_PaymentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<M_PaymentType>()
                .HasMany(e => e.T_Order)
                .WithRequired(e => e.M_PaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PaymentType>()
                .HasMany(e => e.T_PaymentDetails)
                .WithRequired(e => e.M_PaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            //modelBuilder.Entity<M_Product>()
            //    .HasMany(e => e.M_ProductImage)
            //    .WithRequired(e => e.M_Product)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Product>()
                .HasMany(e => e.M_ProductInventory)
                .WithRequired(e => e.M_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Product>()
                .HasMany(e => e.M_ProductPrice)
                .WithRequired(e => e.M_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Product>()
                .HasMany(e => e.T_OrderDetails)
                .WithRequired(e => e.M_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_ProductInventory>()
                .Property(e => e.SKU)
                .IsUnicode(false);

            modelBuilder.Entity<M_ProductPrice>()
                .Property(e => e.TaxExcludedPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<M_ProductPrice>()
                .Property(e => e.TaxIncludedPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<M_ProductPrice>()
                .Property(e => e.TaxRate)
                .HasPrecision(12, 2);

            modelBuilder.Entity<M_ProductPrice>()
                .Property(e => e.ComparedPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.Width)
                .HasPrecision(8, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.Height)
                .HasPrecision(8, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.Depth)
                .HasPrecision(8, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.ExtraShippingFees)
                .HasPrecision(12, 2);

            modelBuilder.Entity<M_ProductShipping>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.LandMark)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Pincode)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<M_ShippingAddress>()
                .HasMany(e => e.T_Order)
                .WithRequired(e => e.M_ShippingAddress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<M_State>()
                .Property(e => e.StateCode)
                .IsUnicode(false);

            modelBuilder.Entity<M_Status>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<M_Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<M_Status>()
                .HasMany(e => e.T_Order)
                .WithRequired(e => e.M_Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Status>()
                .HasMany(e => e.T_StatusHistory)
                .WithRequired(e => e.M_Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Bill>()
                .Property(e => e.BillAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_Bill>()
                .Property(e => e.CC_No)
                .IsUnicode(false);

            modelBuilder.Entity<T_BillItems>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_BillItems>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_BillItems>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_BillItems>()
                .Property(e => e.FinalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_Order>()
                .Property(e => e.Amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_Order>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<T_Order>()
                .HasMany(e => e.T_OrderDetails)
                .WithRequired(e => e.T_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Order>()
                .HasMany(e => e.T_PaymentDetails)
                .WithRequired(e => e.T_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Order>()
                .HasMany(e => e.T_StatusHistory)
                .WithRequired(e => e.T_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_OrderDetails>()
                .Property(e => e.TotalPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.Amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.CGST)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.SGST)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.OtherTax)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.GrandTotal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.PaymentReferenceNo)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.CVVNumber)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.NameOnCard)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.TransactionId)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.TransactionStatus)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.ChecqueNumber)
                .IsUnicode(false);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.ChecqueAmount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<T_PaymentDetails>()
                .Property(e => e.DrawnOnBank)
                .IsUnicode(false);
        }
    }
}
