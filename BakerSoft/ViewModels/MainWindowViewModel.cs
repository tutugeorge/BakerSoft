using log4net;
using Prism.Commands;
using Prism.Regions;


namespace GSTBill.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private static readonly ILog log = LogManager.GetLogger(
  System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> GoToSaleCmd { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoToSaleCmd = new DelegateCommand<string>(GoToSale);
        }

        private void GoToSale(string navigatePath)
        {
            log.Debug("log this message");
            
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
