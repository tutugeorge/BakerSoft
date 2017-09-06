using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
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
        PurchaseTransactionModel _purchaseTransaction;
        SupplierModel _supplierModel;
        ProductModel _products;

        public DelegateCommand<string> GoToViewCmd { get; set; }
        public DelegateCommand PurchaseCmd { get; set; }
        public DelegateCommand<string> SearchProductByIdCmd { get; private set; }

        private List<string> _paymentModeList;
        public List<string> PaymentModeList
        {
            get { return _paymentModeList; }
            set
            {
                SetProperty(ref _paymentModeList, value);
            }
        }
        private List<ProductCategory> _taxRateList;
        public List<ProductCategory> TaxRateList
        {
            get
            {
                return _taxRateList;
            }
            set
            {
                SetProperty(ref _taxRateList, value);
            }
        }
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
        private int _selectedUOM;
        public int SelectedUOM
        {
            get { return _selectedUOM; }
            set { SetProperty(ref _selectedUOM, value); }
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
        private int _selectedTaxRate;
        public int SelectedTaxRate
        {
            get { return _selectedTaxRate; }
            set { SetProperty(ref _selectedTaxRate, value); }
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
            set
            {
                SetProperty(ref _purchasePrice, value);
                if (Convert.ToInt32(Quantity) >=0 &&
                    Convert.ToInt32(Amount) <= 0)
                    Amount = (Convert.ToInt32(Quantity) * Convert.ToInt32(value)).ToString();
            }
        }
        private string _sellingPrice;
        public string SellingPrice
        {
            get { return _sellingPrice; }
            set { SetProperty(ref _sellingPrice, value); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                SetProperty(ref _quantity, value);
                if (Convert.ToInt32(PurchasePrice) >= 0 &&
                    Convert.ToInt32(Amount) <= 0)
                    Amount = (Convert.ToInt32(PurchasePrice) * Convert.ToInt32(value)).ToString();
            }
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
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public AddPurchaseViewModel(IRegionManager regionManager,
                                    PurchaseTransactionModel purchaseTransaction,
                                    SupplierModel supplierModel,
                                    ProductModel products)
        {
            _purchaseTransaction = purchaseTransaction;
            _regionManager = regionManager;
            _supplierModel = supplierModel;
            _products = products;

            SupplierList = _supplierModel.GetSuppliers();
            UOMList = _products.GetUoMCategories();
            TaxRateList = _products.GetProductCategories();
            PaymentModeList = new List<string>()
            {
                "CASH", "CARD"
            };

            GoToViewCmd = new DelegateCommand<string>(GoToView);
            PurchaseCmd = new DelegateCommand(Purchase);
            SearchProductByIdCmd = new DelegateCommand<string>(SearchProductById);
            NotificationRequest = new InteractionRequest<INotification>();
        }

        private void RaiseNotification(string title, string message)
        {
            this.NotificationRequest.Raise(
               new Notification { Content = message, Title = title });
        }

        private void GoToView(string navPath)
        {
            _regionManager.RequestNavigate("ContentRegion", navPath);
        }

        private void Purchase()
        {
            var transaction = new PurchaseTransaction();
            var product = new PurchaseProduct();
            product.ProductId = Convert.ToInt32(ProductId);
            product.PurchasePrice = Convert.ToDecimal(PurchasePrice);
            product.SellingPrice = Convert.ToDecimal(SellingPrice);
            product.Quantity = Convert.ToInt32(Quantity);
            //product.Product = new Product()
            //{
            //    ProductId = Convert.ToInt32(ProductId)
            //};

            //product.ProductName = ProductName;
            //product.ProductCategoryId = SelectedTaxRate;
            //product.ProductUoM = SelectedUOM;            
            transaction.ItemList.Add(product);
            transaction.PaymentList.Add(new PurchasePayment()
            {                
                PaymentAmount = Convert.ToDecimal(Amount),
                Payment = new Payment()
                {
                    PaidAmount = Convert.ToDecimal(Amount),
                    PaymentDate = DateTime.Today,
                    PaymentType = 1
        }
            });
            //To do
            //transaction.PurchaseTaxTotal = //Compute tax from SelectedTaxRate
            transaction.PurchaseTaxTotal = Convert.ToDecimal(1.00);
            transaction.SupplierId = SelectedSupplierId;
            transaction.PurchaseTxnTotal = Convert.ToDecimal(Amount);
            transaction.BillNumber = BillNumber;
            transaction.GSTIN = GSTIN;
            transaction.PurchaseDate = DateTime.Today;
            _purchaseTransaction.Complete(transaction);

            ResetUI();
        }

        private void SearchProductById(string id)
        {
            try
            {
                var product = _products.GetProductDetails(Convert.ToInt32(id));                
                ProductName = product.ProductName;
                ProductId = Convert.ToString(product.ProductId);
                SelectedUOMIndex = FindUOMIndex(product.ProductUoM);
                SelectedTaxRate = FindTaxRateIndex(product.ProductCategoryId);
            }
            catch (Exception)
            {
                RaiseNotification("Error", "Invalid Product");                
            }
        }

        private int FindTaxRateIndex(int productCategoryId)
        {
            int index = 1;
            for (int i = 0; i < TaxRateList.Count; i++)
                if (TaxRateList[i].CategoryId.Equals(productCategoryId))
                {
                    index = i + 1;
                    break;
                }
            return index;
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

        private void ResetUI()
        {
            ProductId = "";
            ProductName = "";
            Quantity = "0";
            SellingPrice = "0";
            PurchasePrice = "0";
            Amount = "0";
        }
    }
}
