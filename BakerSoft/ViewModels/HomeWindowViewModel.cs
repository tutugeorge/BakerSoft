using log4net;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.ViewModels
{
    class HomeWindowViewModel : BaseViewModel
    {
        private static readonly ILog log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> GoToSaleCmd { get; private set; }

        public HomeWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoToSaleCmd = new DelegateCommand<string>(GoToSale);
        }

        private void GoToSale(string navigatePath)
        {
            log.Info("log this message");
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
