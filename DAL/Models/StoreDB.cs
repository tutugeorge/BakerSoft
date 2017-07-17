namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDB : DbContext
    {
        public StoreDB()
            : base("name=StoreDB")
        {
        }

        public virtual DbSet<ADDRESS> ADDRESSes { get; set; }
        public virtual DbSet<CATEGORY_TAX_DEFINITION> CATEGORY_TAX_DEFINITION { get; set; }
        public virtual DbSet<PAYMENT_ATTRIBUTES> PAYMENT_ATTRIBUTES { get; set; }
        public virtual DbSet<PAYMENT> PAYMENTS { get; set; }
        public virtual DbSet<PRODUCT_CATEGORY_MASTER> PRODUCT_CATEGORY_MASTER { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<PURCHASE_TRANSACTIONS> PURCHASE_TRANSACTIONS { get; set; }
        public virtual DbSet<SALE_TRANSACTIONS> SALE_TRANSACTIONS { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERS { get; set; }
        public virtual DbSet<TAX_MASTER> TAX_MASTER { get; set; }
        public virtual DbSet<UOM_CATEGORY_MASTER> UOM_CATEGORY_MASTER { get; set; }
        public virtual DbSet<UOM_DEFINITION_MASTER> UOM_DEFINITION_MASTER { get; set; }
        public virtual DbSet<PURCHASE_PAYMENTS> PURCHASE_PAYMENTS { get; set; }
        public virtual DbSet<PURCHASE_PRODUCTS> PURCHASE_PRODUCTS { get; set; }
        public virtual DbSet<SALES_PAYMENTS> SALES_PAYMENTS { get; set; }
        public virtual DbSet<SALES_PRODUCTS> SALES_PRODUCTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>()
                .HasMany(e => e.SUPPLIERS)
                .WithRequired(e => e.ADDRESS)
                .HasForeignKey(e => e.SupplierAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYMENT>()
                .Property(e => e.PaidAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAYMENT>()
                .HasMany(e => e.PAYMENT_ATTRIBUTES)
                .WithRequired(e => e.PAYMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYMENT>()
                .HasMany(e => e.PURCHASE_PAYMENTS)
                .WithRequired(e => e.PAYMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYMENT>()
                .HasMany(e => e.SALES_PAYMENTS)
                .WithRequired(e => e.PAYMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT_CATEGORY_MASTER>()
                .HasMany(e => e.CATEGORY_TAX_DEFINITION)
                .WithRequired(e => e.PRODUCT_CATEGORY_MASTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT_CATEGORY_MASTER>()
                .HasMany(e => e.PRODUCTS)
                .WithRequired(e => e.PRODUCT_CATEGORY_MASTER)
                .HasForeignKey(e => e.ProductCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.PURCHASE_PRODUCTS)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.SALES_PRODUCTS)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PURCHASE_TRANSACTIONS>()
                .Property(e => e.PurchaseTxnTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PURCHASE_TRANSACTIONS>()
                .Property(e => e.PurchaseTaxTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PURCHASE_TRANSACTIONS>()
                .HasMany(e => e.PURCHASE_PRODUCTS)
                .WithRequired(e => e.PURCHASE_TRANSACTIONS)
                .HasForeignKey(e => e.PurchaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PURCHASE_TRANSACTIONS>()
                .HasMany(e => e.PURCHASE_PAYMENTS)
                .WithRequired(e => e.PURCHASE_TRANSACTIONS)
                .HasForeignKey(e => e.PaymentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .Property(e => e.TransactionTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .Property(e => e.TransactionTaxTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .Property(e => e.TransactionDiscountTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .HasMany(e => e.SALES_PRODUCTS)
                .WithRequired(e => e.SALE_TRANSACTIONS)
                .HasForeignKey(e => e.SaleTransactionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .HasMany(e => e.SALES_PAYMENTS)
                .WithRequired(e => e.SALE_TRANSACTIONS)
                .HasForeignKey(e => e.SaleTransactionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALE_TRANSACTIONS>()
                .HasOptional(e => e.SALE_TRANSACTIONS1)
                .WithRequired(e => e.SALE_TRANSACTIONS2);

            modelBuilder.Entity<SUPPLIER>()
                .HasMany(e => e.PURCHASE_TRANSACTIONS)
                .WithRequired(e => e.SUPPLIER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAX_MASTER>()
                .Property(e => e.TaxChar)
                .IsFixedLength();

            modelBuilder.Entity<TAX_MASTER>()
                .Property(e => e.TaxRate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TAX_MASTER>()
                .HasMany(e => e.CATEGORY_TAX_DEFINITION)
                .WithRequired(e => e.TAX_MASTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UOM_CATEGORY_MASTER>()
                .HasMany(e => e.PRODUCTS)
                .WithRequired(e => e.UOM_CATEGORY_MASTER)
                .HasForeignKey(e => e.ProductUoM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UOM_CATEGORY_MASTER>()
                .HasOptional(e => e.UOM_DEFINITION_MASTER)
                .WithRequired(e => e.UOM_CATEGORY_MASTER);

            modelBuilder.Entity<UOM_DEFINITION_MASTER>()
                .Property(e => e.UoMConversionFactor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UOM_DEFINITION_MASTER>()
                .HasMany(e => e.SALES_PRODUCTS)
                .WithRequired(e => e.UOM_DEFINITION_MASTER)
                .HasForeignKey(e => e.UoM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PURCHASE_PAYMENTS>()
                .Property(e => e.PaymentAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PURCHASE_PRODUCTS>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PURCHASE_PRODUCTS>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PURCHASE_PRODUCTS>()
                .Property(e => e.SellingPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALES_PAYMENTS>()
                .Property(e => e.PaymentAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALES_PRODUCTS>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALES_PRODUCTS>()
                .Property(e => e.SellingPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SALES_PRODUCTS>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(18, 0);
        }
    }
}
