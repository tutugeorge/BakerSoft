using BakerSoft.Models;
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
        SupplierModel _supplierModel;
        ProductModel _products;

        public DelegateCommand<string> GoToViewCmd { get; set; }
        public DelegateCommand PurchaseCmd { get; set; }
        public DelegateCommand<string> SearchProductByIdCmd { get; private set; }

        private int _selectedSupplierIndex;
        public int SelectedSupplierIndex
        {
            get { return _selectedSupplierIndex; }
            set
            {
                SetProperty(ref _selectedSupplierIndex, value);                
            }
        }
        private int _selectedUOMIndex;
        public int SelectedUOMIndex
        {
            get { return _selectedUOMIndex; }
            set { SetProperty(ref _selectedUOMIndex, value); }
        }
        private List<UomCategory> _uomList;
        public List<UomCategory> UOMList
        {
            get
            {
                return _uomList;
            }
            set
            {
                SetProperty(ref _uomList, value);
            }
        }
        private string _selectedSupplierId;
        public string SelectedSupplierId
        {
            get { return _selectedSupplierId; }
            set
            {
                SetProperty(ref _selectedSupplierId, value);
                GSTIN = FindGSTN(value);
            }
        }
        private List<Supplier> _supplierList;
        public List<Supplier> SupplierList
        {
            get { return _supplierList; }
            set { SetProperty(ref _supplierList, value); }
        } 
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
                                    PurchaseTransaction purchaseTransaction,
                                    SupplierModel supplierModel,
                                    ProductModel products)
        {
            _purchaseTransaction = purchaseTransaction;
            _regionManager = regionManager;
            _supplierModel = supplierModel;
            _products = products;

            SupplierList = _supplierModel.GetSuppliers();
            UOMList = _products.GetUoMCategories();            

            GoToViewCmd = new DelegateCommand<string>(GoToView);
            PurchaseCmd = new DelegateCommand(Purchase);
            SearchProductByIdCmd = new DelegateCommand<string>(SearchProductById);
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

        private void SearchProductById(string id)
        {
            var products = _products.SearchById(id);
            ProductName = products[0].ProductName;
            SelectedUOMIndex = FindUOMIndex(products[0].ProductUoM);
        }

        private int FindUOMIndex(int value)
        {
            int index = 0;
            for (int i = 0; i < UOMList.Count; i++)
                if (UOMList[i].UoMCategoryId.Equals(value))
                    index = i;
            return index;
        }

        private string FindGSTN(string value)
        {
            foreach (var item in SupplierList)
                if (item.SupplierId.Equals(value))
                    return item.SupplierGST;

            return "";
        }
    }
}
