using BakerSoft.Models;
using GSTBill.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.ViewModels
{
    class SaleViewModel : BaseViewModel
    {
        private SaleTransaction _saleTransaction;
        private ProductModel _products;

        public DelegateCommand CheckoutCmd { get; private set; }
        public DelegateCommand CancelSaleCmd { get; private set; }
        public DelegateCommand<Product> AddProductCmd { get; private set; }
        public DelegateCommand<int?> RemoveProductCmd { get; private set; }
        public DelegateCommand<string> SearchProductByNameCmd { get; private set; }
        public DelegateCommand<string> SearchProductByIdCmd { get; private set; }

        private string _productSearchName;
        public string ProductSearchName
        {
            get { return _productSearchName; }
            set { SetProperty(ref _productSearchName, value); }
        }

        private Product _selectedSearchItem;
        public Product SelectedSearchItem
        {
            get { return _selectedSearchItem; }
            set
            {
                SetProperty(ref _selectedSearchItem, value);
                if(_selectedSearchItem != null)
                    SelectedUOM = _selectedSearchItem.ProductUoM; 
            }
        }
        private int _selectedUOM;
        public int SelectedUOM
        {
            get { return _selectedUOM; }
            set { SetProperty(ref _selectedUOM, value); }
        }
        private List<UOM> _uomList;
        public List<UOM> UOMList
        {
            get
            {
                if (_uomList == null)
                {
                    _uomList = new List<UOM>()
                    {
                        new UOM() { Id =1, Name = "Packet" },
                        new UOM() { Id =2, Name = "Piece" },
                        new UOM() { Id =3, Name = "Gram" },
                        new UOM() { Id =4, Name = "Litre" }
                    };
                }
                return _uomList;
            }
            set
            {
                SetProperty(ref _uomList, value);
            }
        }
        private bool _isAddItemEnabled;       
        public bool IsAddItemEnabled
        {
            get { return _isAddItemEnabled; }
            set { SetProperty(ref _isAddItemEnabled, value); }
        }
        private int _selectedSearchItemIndex;
        public int SelectedSearchItemIndex
        {
            get
            {
                return _selectedSearchItemIndex;
            }
            set
            {
                SetProperty(ref _selectedSearchItemIndex, value);
                if (_selectedSearchItemIndex > -1)
                    IsAddItemEnabled = true;
                else
                    IsAddItemEnabled = false;
            }
        }
        private bool _isRemoveItemEnabled;
        public bool IsRemoveItemEnabled
        {
            get { return _isRemoveItemEnabled; }
            set { SetProperty(ref _isRemoveItemEnabled, value); }
        }
        private int _selectedItemIndex;
        public int SelectedItemIndex
        {
            get
            {
                return _selectedItemIndex;
            }
            set
            {
                SetProperty(ref _selectedItemIndex, value);
                if (_selectedItemIndex > -1)
                    IsRemoveItemEnabled = true;
                else
                    IsRemoveItemEnabled = false;
            }
        }
        private string _quantity;
        public string Quantity
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_quantity))
                    _quantity = "1";        
                return _quantity;
            }
            set { SetProperty(ref _quantity, value); }
        }
        private string _total;
        public string Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }
        public Product SelectedProduct { get; set; }        
        private List<Product> _searchResult = new List<Product>();
        public List<Product> SearchResult
        {
            get { return _searchResult; }
            set { SetProperty(ref _searchResult, value); }
        }
        private List<Product> _itemList = new List<Product>();
        public List<Product> ItemList
        {
            get { return _itemList; }
            set { SetProperty(ref _itemList, value); }                       
        }

        public SaleViewModel(SaleTransaction saleTransaction,
                            ProductModel products)
        {
            _saleTransaction = saleTransaction;
            _products = products;

            CheckoutCmd = new DelegateCommand(Checkout);
            CancelSaleCmd = new DelegateCommand(CancelSale);
            AddProductCmd = new DelegateCommand<Product>(AddProduct);
            RemoveProductCmd = new DelegateCommand<int?>(RemoveProduct);
            SearchProductByNameCmd = new DelegateCommand<string>(SearchProductByName);
            SearchProductByIdCmd = new DelegateCommand<string>(SearchProductById);
        }

        private void Checkout()
        {
            _saleTransaction.Complete();
            UpdateTransaction();
        }

        private void CancelSale()
        {
            _saleTransaction.Cancel();
            UpdateTransaction();
        }

        private void AddProduct(Product product)
        {
            product.Quantity = Convert.ToInt32(Quantity);
            _saleTransaction.AddItem(product);
            UpdateTransaction();
        }

        private void RemoveProduct(int? index)
        {
            int itemIndex = Convert.ToInt32(index);
            _saleTransaction.RemoveItem(itemIndex);
            UpdateTransaction();
        }

        private void UpdateTransaction()
        {
            SearchResult = null;
            ItemList = null;
            ItemList = _saleTransaction.ItemList;
            Total = (_saleTransaction.TransactionTotal +
                    _saleTransaction.TransactionTaxTotal).ToString("F2");
            Quantity = "1";
        }

        private void SearchProductByName(string name)
        {
            SearchResult = _products.SearchByName(name);
        }

        private void SearchProductById(string id)
        {
            SearchResult = _products.SearchById(id);            
        }
    }
}
