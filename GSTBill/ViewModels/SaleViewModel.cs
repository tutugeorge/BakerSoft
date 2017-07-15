using GSTBill.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.ViewModels
{
    class SaleViewModel : BaseViewModel
    {
        private SaleTransaction _saleTransaction;

        public DelegateCommand CheckoutCmd { get; private set; }
        public DelegateCommand AddProductCmd { get; private set; }
        public DelegateCommand SearchProductByNameCmd { get; private set; }

        public SaleViewModel(SaleTransaction saleTransaction)
        {
            _saleTransaction = saleTransaction;
            CheckoutCmd = new DelegateCommand(Checkout);
            AddProductCmd = new DelegateCommand(AddProduct);
            SearchProductByNameCmd = new DelegateCommand(SearchProductByName);
        }

        private void Checkout()
        {
            _saleTransaction.Complete();
        }

        public void AddProduct()
        {
            _saleTransaction.AddItem();
        }

        public void SearchProductByName()
        {

        }
    }
}
