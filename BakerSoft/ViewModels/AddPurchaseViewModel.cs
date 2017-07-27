using GSTBill.Models;
using GSTBill.ViewModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddPurchaseViewModel : BaseViewModel
    {
        PurchaseTransaction _purchaseTransaction;

        public DelegateCommand PurchaseCmd { get; set; }

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
        public AddPurchaseViewModel(PurchaseTransaction purchaseTransaction)
        {
            _purchaseTransaction = purchaseTransaction;

            PurchaseCmd = new DelegateCommand(Purchase);
        }

        private void Purchase()
        {

        }
    }
}
