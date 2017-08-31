using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
using log4net;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        private static readonly ILog log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ProductModel _productModel;

        private int _selectedUOM;
        public int SelectedUOM
        {
            get { return _selectedUOM; }
            set { SetProperty(ref _selectedUOM, value); }
        }
        private int _selectedTaxRate;
        public int SelectedTaxRate
        {
            get { return _selectedTaxRate; }
            set { SetProperty(ref _selectedTaxRate, value); }
        }
        private string _productSearchId;
        public string ProductSearchId
        {
            get { return _productSearchId; }
            set { SetProperty(ref _productSearchId, value); }
        }
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }
        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set { SetProperty(ref _productDescription, value); }
        }
        private string _sellingPrice;
        public string SellingPrice
        {
            get { return _sellingPrice; }
            set { SetProperty(ref _sellingPrice, value); }
        }
        public Tax ProductTax { get; set; }
        public List<Price> PriceList { get; set; }
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
        private List<UomCategory> _uomList;
        public List<UomCategory> UOMList
        {
            get
            {
                //if (_uomList == null)
                //{
                //    _uomList = new List<UOM>()
                //    {
                //        new UOM() { Id =1, Name = "Packet" },
                //        new UOM() { Id =2, Name = "Piece" },
                //        new UOM() { Id =3, Name = "Gram" },
                //        new UOM() { Id =4, Name = "Litre" }
                //    };
                //}
                return _uomList;
            }
            set
            {
                SetProperty(ref _uomList, value);                
            }
        }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        //Add other data capture items for product
        public DelegateCommand AddProductCmd { get; set; }

        public AddProductViewModel(ProductModel productModel)
        {
            _productModel = productModel;

            AddProductCmd = new DelegateCommand(AddProduct);
            NotificationRequest = new InteractionRequest<INotification>();

            TaxRateList = _productModel.GetProductCategories();
            UOMList = _productModel.GetUoMCategories();       
        }

        private void RaiseNotification(string title, string message)
        {
            this.NotificationRequest.Raise(
               new Notification { Content = message, Title = title });
        }

        private void AddProduct()
        {
            if(!ValidateInputFields())
            {
                RaiseNotification("Alert", "Please enter all the required fields");
                return;
            }
            var product = new Product();
            try
            {                
                product.ProductName = ProductName;
                product.ProductSearchId = Convert.ToInt32(ProductSearchId);
                product.ProductUoM = SelectedUOM;
                //product.PriceList = new List<Price>()
                //{ new Price() { SellingPrice = Convert.ToDouble(this.SellingPrice) } };
                product.ProductDescription = ProductDescription;
                var taxRate = new Tax()
                {
                    TaxId = SelectedTaxRate
                };
                product.ProductTax = taxRate;
                _productModel.Add(product);
                log.Info(String.Format("New product {0} added successfully", ProductDescription ));
            }
            catch (Exception ex)
            {
                log.Error(product, ex);
            }
            finally
            {
                ResetUI();
            }
        }

        private void ResetUI()
        {
            ProductName = "";
            ProductSearchId = "";
            SelectedUOM = 0;
            SellingPrice = "0.00";
            ProductDescription = "";
            SelectedTaxRate = 0;
        }

        private bool ValidateInputFields()
        {
            if (string.IsNullOrWhiteSpace(ProductName))
                return false;
            return true;
        }
    }
}
