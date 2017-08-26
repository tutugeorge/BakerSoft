using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;

namespace DAL.LiteDB
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("LiteDB")
        {
            Configure();
        }

        public StoreDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new StoreDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);

            //InitLiteDb();
        }

        private void InitLiteDb()
        {
            using (var litedb = this)
            {
                if (litedb.Set<DAL.Models.ADDRESS>().Count() != 0)
                {
                    //return;
                }

                //litedb.Set<DAL.Models.UOM_CATEGORY_MASTER>().Add(new DAL.Models.UOM_CATEGORY_MASTER()
                //{
                //    UoMCategoryCode = "2",
                //    UoMCategoryId = 2,
                //    UoMCategoryDescription = "Litre"
                //});
                litedb.Set<DAL.Models.UOM_CATEGORY_MASTER>().Add(new DAL.Models.UOM_CATEGORY_MASTER()
                {
                    UoMCategoryCode = "1",
                    UoMCategoryId = 1,
                    UoMCategoryDescription = "KiloGram"
                });
                //litedb.Set<DAL.Models.UOM_DEFINITION_MASTER>().Add(new DAL.Models.UOM_DEFINITION_MASTER()
                //{
                //    UoMCode = "1",
                //    UoMDescription = "Gram",
                //    UoMCategoryId = 1,
                //    UoMConversionFactor = 0.001m
                //});
                litedb.Set<DAL.Models.UOM_DEFINITION_MASTER>().Add(new DAL.Models.UOM_DEFINITION_MASTER()
                {
                    UoMCode = "1",
                    UoMDescription = "KiloGram",
                    UoMCategoryId = 1,
                    UoMConversionFactor = 0.001m
                });
                litedb.Set<DAL.Models.TAX_MASTER>().Add(new DAL.Models.TAX_MASTER()
                {
                    TaxId = 1,
                    TaxRate = 0.18m,
                    TaxChar = "@",
                    TaxDescription = "18 %"
                });
                litedb.Set<DAL.Models.CATEGORY_TAX_DEFINITION_NEW>().Add(new DAL.Models.CATEGORY_TAX_DEFINITION_NEW()
                {
                    Description = "18 %",
                    SequenceId = 1,
                    TaxId = 1
                });
                //litedb.Set<DAL.Models.TAX_MASTER>().Add(new DAL.Models.TAX_MASTER()
                //{
                //    TaxId = 2,
                //    TaxRate = 0.12m,
                //    TaxChar = "#",
                //    TaxDescription = "12 %"
                //});
                litedb.Set<DAL.Models.PRODUCT_CATEGORY_MASTER_NEW>().Add(new DAL.Models.PRODUCT_CATEGORY_MASTER_NEW()
                {
                    CategoryTaxId = 1,
                    CategoryName = "18 %",
                    CategoryDescription = "Luxury items"
                });
                //litedb.Set<DAL.Models.PRODUCT_CATEGORY_MASTER_NEW>().Add(new DAL.Models.PRODUCT_CATEGORY_MASTER_NEW()
                //{
                //    CategoryTaxId = 2,
                //    CategoryName = "12 %",  
                //    CategoryDescription = "Biscuits"
                //});
                litedb.SaveChanges();
            }
        }
    }
}
