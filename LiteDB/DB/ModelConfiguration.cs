using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LiteDB
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureTeamEntity(modelBuilder);
            //ConfigureStadionEntity(modelBuilder);
            //ConfigureCoachEntity(modelBuilder);
            //ConfigurePlayerEntity(modelBuilder);
            //ConfigureSelfReferencingEntities(modelBuilder);
        }

        private static void ConfigureTeamEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>()
                .HasMany(e => e.SUPPLIERS)
                .WithRequired(e => e.ADDRESS)
                .HasForeignKey(e => e.SupplierAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORY_TAX_DEFINITION_NEW>()
                .HasMany(e => e.PRODUCT_CATEGORY_MASTER_NEW)
                .WithRequired(e => e.CATEGORY_TAX_DEFINITION_NEW)
                .HasForeignKey(e => e.CategoryTaxId)
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

            modelBuilder.Entity<PRODUCT_CATEGORY_MASTER_NEW>()
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
                .HasForeignKey(e => e.PurchaseId)
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

            //modelBuilder.Entity<SALE_TRANSACTIONS>()
            //    .HasOptional(e => e.SALE_TRANSACTIONS1)
            //    .WithRequired(e => e.SALE_TRANSACTIONS2);

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
                .HasMany(e => e.UOM_DEFINITION_MASTER)
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

        //private static void ConfigureStadionEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Stadion>();
        //}

        //private static void ConfigureCoachEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Coach>()
        //        .HasRequired(p => p.Team)
        //        .WithRequiredPrincipal(t => t.Coach)
        //        .WillCascadeOnDelete(false);
        //}

        //private static void ConfigurePlayerEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Player>()
        //        .HasRequired(p => p.Team)
        //        .WithMany(team => team.Players)
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureSelfReferencingEntities(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Foo>();
        //    modelBuilder.Entity<FooSelf>();
        //    modelBuilder.Entity<FooStep>();
        //}
    }
}
