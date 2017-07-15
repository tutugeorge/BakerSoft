using GSTBill.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Modules
{
    public class SaleModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public SaleModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<SaleView>();    
                   
        }
    }
}
