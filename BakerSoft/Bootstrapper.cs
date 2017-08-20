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

namespace GSTBill
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            using (var litedb = new DAL.LiteDB.StoreDbContext())
            {
                if (litedb.Set<DAL.Models.ADDRESS>().Count() != 0)
                {
                    //return;
                }

                litedb.Set<DAL.Models.ADDRESS>().Add(new DAL.Models.ADDRESS()
                {
                    AddressId = 1,
                    AddressLine1 = "1",
                    AddressLine2 = "2",
                    AddressLine3 = "3",
                    City = "c",
                    Pincode = "p",
                    State = "s"
                });
                litedb.SaveChanges();
            }

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
            Container.RegisterType<ISupplierRepository, SupplierRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
            //Container.RegisterType<IProductRepository, MockProductRepo>();
            //Container.RegisterType<ISupplierRepository, MockSupplierRepo>();


            var transactionRepo = Container.Resolve<ITransactionRepository>() as SaleTransactionRepository;
            var productsRepo = Container.Resolve<IProductRepository>() as ProductRepository;
            var supplierRepo = Container.Resolve<ISupplierRepository>() as SupplierRepository;
            //var productsRepo = Container.Resolve<IProductRepository>() as MockProductRepo;
            //var supplierRepo = Container.Resolve<ISupplierRepository>() as MockSupplierRepo;
            Container.RegisterInstance(typeof(SaleTransaction), new SaleTransaction(transactionRepo));
            Container.RegisterInstance(typeof(ProductModel), new ProductModel(productsRepo));
            Container.RegisterInstance(typeof(SupplierModel), new SupplierModel(supplierRepo));
        }
    }
}
