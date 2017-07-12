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

        public SaleViewModel(SaleTransaction saleTransaction)
        {
            _saleTransaction = saleTransaction;
            CheckoutCmd = new DelegateCommand(Checkout);
        }

        private void Checkout()
        {
            _saleTransaction.Add();
        }
    }
}
