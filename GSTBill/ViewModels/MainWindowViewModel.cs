using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> GoToSaleCmd { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoToSaleCmd = new DelegateCommand<string>(GoToSale);
        }

        private void GoToSale(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
