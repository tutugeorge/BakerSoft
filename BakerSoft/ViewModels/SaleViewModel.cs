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
        public DelegateCommand SearchProductByNameCmd { get; private set; }
        public DelegateCommand<string> SearchProductByIdCmd { get; private set; }

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
            SearchProductByNameCmd = new DelegateCommand(SearchProductByName);
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
            _saleTransaction.AddItem(product);
            UpdateTransaction();
        }

        private void RemoveProduct()
        {
            _saleTransaction.RemoveItem(SelectedProduct);
            UpdateTransaction();
        }

        private void UpdateTransaction()
        {
            SearchResult = null;
            ItemList = null;
            ItemList = _saleTransaction.ItemList;
            Total = (_saleTransaction.TransactionTotal +
                    _saleTransaction.TransactionTaxTotal).ToString("F2");
        }

        private void SearchProductByName()
        {

        }

        private void SearchProductById(string id)
        {
            SearchResult = _products.SearchById(id);            
        }
    }
}
