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
        private Products _products;

        public DelegateCommand CheckoutCmd { get; private set; }
        public DelegateCommand CancelSaleCmd { get; private set; }
        public DelegateCommand AddProductCmd { get; private set; }
        public DelegateCommand SearchProductByNameCmd { get; private set; }
        public DelegateCommand SearchProductByIdCmd { get; private set; }

        public SaleItem SelectedProduct { get; set; }
        public ObservableCollection<SaleItem> SearchResult { get; set; }
        public ObservableCollection<SaleItem> ItemList
        {
            get { return _saleTransaction.ItemList; }            
        }

        public SaleViewModel(SaleTransaction saleTransaction,
                            Products products)
        {
            _saleTransaction = saleTransaction;
            _products = products;

            CheckoutCmd = new DelegateCommand(Checkout);
            CancelSaleCmd = new DelegateCommand(CancelSale);
            AddProductCmd = new DelegateCommand(AddProduct);
            SearchProductByNameCmd = new DelegateCommand(SearchProductByName);
            SearchProductByIdCmd = new DelegateCommand(SearchProductById);
        }

        private void Checkout()
        {
            _saleTransaction.Complete();
        }

        private void CancelSale()
        {

        }

        private void AddProduct()
        {
            _saleTransaction.AddItem(SelectedProduct);
        }

        private void RemoveProduct()
        {

        }

        private void SearchProductByName()
        {

        }

        private void SearchProductById()
        {

        }
    }
}
