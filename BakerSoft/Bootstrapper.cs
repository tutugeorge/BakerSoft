﻿using Prism.Unity;
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

namespace GSTBill
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // To be removed . 
            //Added for testing code firt in sqlite with EF


            //using (var litedb = new DAL.LiteDB.StoreDbContext())
            //{
            //    if (litedb.Set<DAL.Models.ADDRESS>().Count() != 0)
            //    {
            //        //return;
            //    }

            //    litedb.Set<DAL.Models.UOM_CATEGORY_MASTER>().Add(new DAL.Models.UOM_CATEGORY_MASTER()
            //    {
            //        UoMCategoryCode = "2",
            //        UoMCategoryId = 2,
            //        UoMCategoryDescription = "Litre"
            //    });
            //    litedb.SaveChanges();
            //}

            //return Container.Resolve<MainWindow>();
            return Container.Resolve<HomeWindow>();
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
            Container.RegisterType<ITransactionRepository, SaleTransactionRepository>();


            #region SQL Repo
            //Container.RegisterType<ISupplierRepository, SupplierRepository>();
            //Container.RegisterType<IProductRepository, ProductRepository>();
            //var productsRepo = Container.Resolve<IProductRepository>() as ProductRepository;
            //var supplierRepo = Container.Resolve<ISupplierRepository>() as SupplierRepository;
            #endregion

            #region Mock Repo
            //Container.RegisterType<IProductRepository, MockProductRepo>();
            //Container.RegisterType<ISupplierRepository, MockSupplierRepo>();
            //var productsRepo = Container.Resolve<IProductRepository>() as MockProductRepo;
            //var supplierRepo = Container.Resolve<ISupplierRepository>() as MockSupplierRepo;
            #endregion

            #region Lite Repo
            Container.RegisterType<IPurchaseTransactionRepository, PurchaseTransactionLiteRepository>();
            var purchaseTransactionRepo = Container.Resolve<IPurchaseTransactionRepository>() as PurchaseTransactionLiteRepository;
            Container.RegisterType<ISupplierRepository, SupplierLiteRepository>();
            var supplierRepo = Container.Resolve<ISupplierRepository>() as SupplierLiteRepository;
            Container.RegisterType<IProductRepository, ProductLiteRepository>();
            var productsRepo = Container.Resolve<IProductRepository>() as ProductLiteRepository;
            #endregion

            var transactionRepo = Container.Resolve<ITransactionRepository>() as SaleTransactionRepository;
            
            Container.RegisterInstance(typeof(SaleTransaction), new SaleTransaction(transactionRepo));
            Container.RegisterInstance(typeof(ProductModel), new ProductModel(productsRepo));
            Container.RegisterInstance(typeof(SupplierModel), new SupplierModel(supplierRepo));
            Container.RegisterInstance(typeof(PurchaseTransactionModel), new PurchaseTransactionModel(purchaseTransactionRepo));
        }
    }
}
