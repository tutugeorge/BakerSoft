using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using GSTBill.Views;
using Prism.Modularity;
using GSTBill.Modules;
using GSTBill.Models;
using GSTBill.Definitions;
using GSTBill.Repositories;
using BakerSoft.Definitions;
using BakerSoft.Repositories;
using BakerSoft.Models;
using System.Linq;
using System.Collections.Generic;

namespace GSTBill
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // To be removed . 
            //Added for testing code firt in sqlite with EF


            InitLiteDb();

            //return Container.Resolve<MainWindow>();
            return Container.Resolve<HomeWindow>();
        }

        private static void InitLiteDb()
        {
            using (var litedb = new DAL.LiteDB.StoreDbContext())
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

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(SaleModule));
        }
        //https://msdn.microsoft.com/en-in/library/gg430868(v=pandp.40).aspx

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            #region SQL Repo
            //Container.RegisterType<ITransactionRepository, SaleTransactionRepository>();
            //var transactionRepo = Container.Resolve<ITransactionRepository>() as SaleTransactionRepository;
            //Container.RegisterType<ISupplierRepository, SupplierRepository>();
            //Container.RegisterType<IProductRepository, ProductRepository>();
            //var productsRepo = Container.Resolve<IProductRepository>() as ProductRepository;
            //var supplierRepo = Container.Resolve<ISupplierRepository>() as SupplierRepository;
            //Container.RegisterType<IPurchaseTransactionRepository, PurchaseTransactionRepository>();
            //var purchaseTransactionRepo = Container.Resolve<IPurchaseTransactionRepository>() as PurchaseTransactionRepository;
            #endregion

            #region Mock Repo
            //Container.RegisterType<IProductRepository, MockProductRepo>();
            //Container.RegisterType<ISupplierRepository, MockSupplierRepo>();
            //var productsRepo = Container.Resolve<IProductRepository>() as MockProductRepo;
            //var supplierRepo = Container.Resolve<ISupplierRepository>() as MockSupplierRepo;
            #endregion

            #region Lite Repo
            Container.RegisterType<ISaleTransactionRepository, SaleTransactionLiteRepo>();
            var transactionRepo = Container.Resolve<ISaleTransactionRepository>() as SaleTransactionLiteRepo;
            Container.RegisterType<IPurchaseTransactionRepository, PurchaseTransactionLiteRepository>();
            var purchaseTransactionRepo = Container.Resolve<IPurchaseTransactionRepository>() as PurchaseTransactionLiteRepository;
            Container.RegisterType<ISupplierRepository, SupplierLiteRepository>();
            var supplierRepo = Container.Resolve<ISupplierRepository>() as SupplierLiteRepository;
            Container.RegisterType<IProductRepository, ProductLiteRepository>();
            var productsRepo = Container.Resolve<IProductRepository>() as ProductLiteRepository;
            #endregion

            
            
            Container.RegisterInstance(typeof(SaleTransactionModel), new SaleTransactionModel(transactionRepo));
            Container.RegisterInstance(typeof(ProductModel), new ProductModel(productsRepo));
            Container.RegisterInstance(typeof(SupplierModel), new SupplierModel(supplierRepo));
            Container.RegisterInstance(typeof(PurchaseTransactionModel), new PurchaseTransactionModel(purchaseTransactionRepo));
        }
    }
}
