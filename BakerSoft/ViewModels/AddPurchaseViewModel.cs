using GSTBill.Models;
using GSTBill.ViewModels;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddPurchaseViewModel : BaseViewModel
    {
        IRegionManager _regionManager;
        PurchaseTransaction _purchaseTransaction;

        public DelegateCommand<string> GoToViewCmd { get; set; }
        public DelegateCommand PurchaseCmd { get; set; }

        private string _paymentMode;
        public string PaymentMode
        {
            get { return _paymentMode; }
            set { SetProperty(ref _paymentMode, value); }
        }
        private string _taxRate;
        public string TaxRate
        {
            get { return _taxRate; }
            set { SetProperty(ref _taxRate, value); }
        }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
        private string _billNumber;
        public string BillNumber
        {
            get { return _billNumber; }
            set { SetProperty(ref _billNumber, value); }
        }
        private string _gSTIN;
        public string GSTIN
        {
            get { return _gSTIN; }
            set { SetProperty(ref _gSTIN, value); }
        }
        private string _purchasePrice;
        public string PurchasePrice
        {
            get { return _purchasePrice; }
            set { SetProperty(ref _purchasePrice, value); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }
        private string _supplierName;
        public string SupplierName
        {
            get { return _supplierName; }
            set { SetProperty(ref _supplierName, value); }
        }
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }
        private string _productId;
        public string ProductId
        {
            get { return _productId; }
            set { SetProperty(ref _productId, value); }
        }
        public AddPurchaseViewModel(IRegionManager regionManager,
            PurchaseTransaction purchaseTransaction)
        {
            _purchaseTransaction = purchaseTransaction;
            _regionManager = regionManager;

            GoToViewCmd = new DelegateCommand<string>(GoToView);
            PurchaseCmd = new DelegateCommand(Purchase);
        }

        private void GoToView(string navPath)
        {
            _regionManager.RequestNavigate("ContentRegion", navPath);
        }

        private void Purchase()
        {
            var product = new Product();
            product.ProductId = Convert.ToInt32(ProductId);
            product.ProductName = ProductName;
            product.Quantity = Convert.ToInt32(Quantity);
            product.Tax = TaxRate;
            
            _purchaseTransaction.AddItem(product);

            _purchaseTransaction.BillNumber = BillNumber;
            _purchaseTransaction.GSTIN = GSTIN;
            _purchaseTransaction.Complete();
        }
    }
}
