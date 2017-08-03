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

namespace GSTBill
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
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
            //Container.RegisterType<IProductRepository, ProductRepository>();
            Container.RegisterType<IProductRepository, MockProductRepo>();

            var transactionRepo = Container.Resolve<ITransactionRepository>() as SaleTransactionRepository;
            //var productsRepo = Container.Resolve<IProductRepository>() as ProductRepository;
            var productsRepo = Container.Resolve<IProductRepository>() as MockProductRepo;
            Container.RegisterInstance(typeof(SaleTransaction), new SaleTransaction(transactionRepo));
            Container.RegisterInstance(typeof(ProductModel), new ProductModel(productsRepo));
        }
    }
}
