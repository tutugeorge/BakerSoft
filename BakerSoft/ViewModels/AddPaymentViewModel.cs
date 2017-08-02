using BakerSoft.Models;
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
    class AddPaymentViewModel : BaseViewModel
    {
        SaleTransaction _saleTransaction;

        public DelegateCommand CashPaymentCmd { get; set; } 
        public string CashAmount { get; set; }
        public string PaymentTotal { get; set; }

        public AddPaymentViewModel(SaleTransaction saleTransaction)
        {
            _saleTransaction = saleTransaction;

            CashPaymentCmd = new DelegateCommand(CashPayment);
        }

        private void CashPayment()
        {
            var cashPayment = new Payment()
            {
                Amount = Convert.ToDouble(CashAmount)   
            };
            _saleTransaction.AddPayment(cashPayment);
        }
    }
}
