﻿using GSTBill.Models;
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
        public DelegateCommand AddProductCmd { get; private set; }
        public DelegateCommand SearchProductByNameCmd { get; private set; }
        public DelegateCommand SearchProductByIdCmd { get; private set; }        

        public Product SelectedProduct { get; set; }
        public ObservableCollection<Product> SearchResult { get; set; }
        public ObservableCollection<Product> ItemList
        {
            get { return _saleTransaction.ItemList; }            
        }

        public SaleViewModel(SaleTransaction saleTransaction,
                            ProductModel products)
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
            _saleTransaction.Cancel();
        }

        private void AddProduct()
        {
            _saleTransaction.AddItem(SelectedProduct);
        }

        private void RemoveProduct()
        {
            _saleTransaction.RemoveItem(SelectedProduct);
        }

        private void SearchProductByName()
        {

        }

        private void SearchProductById()
        {

        }
    }
}
