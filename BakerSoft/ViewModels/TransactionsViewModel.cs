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
    class TransactionsViewModel : BaseViewModel
    {
        SaleTransactionModel _saleTransaction;
        PurchaseTransactionModel _purchaseTransaction;

        private List<SaleTransaction> _saleTxnList;
        public List<SaleTransaction> SaleTxnList
        {
            get { return _saleTxnList; }
            set
            {
                SetProperty(ref _saleTxnList, value);
            }
        }
        private List<PurchaseTransaction> _purchaseTxnList;
        public List<PurchaseTransaction> PurchaseTxnList
        {
            get { return _purchaseTxnList; }
            set
            {
                SetProperty(ref _purchaseTxnList, value);
            }
        }

        public DelegateCommand<string> DateFilterCmd { get; set; }

        public TransactionsViewModel(IRegionManager regionManager,
                            SaleTransactionModel saleTransaction,
                            PurchaseTransactionModel purchaseTransaction)
        {
            _saleTransaction = saleTransaction;
            _purchaseTransaction = purchaseTransaction;

            SaleTxnList = _saleTransaction.GetTransactionHistory(DateTime.Today);
            PurchaseTxnList = _purchaseTransaction.GetPurchaseTxnHistory();

            DateFilterCmd = new DelegateCommand<string>(FilterSaleTxnHistory); 
        }

        private void FilterSaleTxnHistory(string filterValue)
        {
            var dateFilter = DateTime.Today;
            if (string.Equals(filterValue, "1"))
            {
                DateTime now = DateTime.Now;
                dateFilter = new DateTime(now.Year, now.Month, 1);                
            }
            SaleTxnList = _saleTransaction.GetTransactionHistory(dateFilter);
        }
    }
}
