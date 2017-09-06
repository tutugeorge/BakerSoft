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

        private decimal _saleTotalAmount;
        public decimal SaleTotalAmount
        {
            get { return _saleTotalAmount; }
            set { SetProperty(ref _saleTotalAmount, value); }
        }
        private decimal _purchaseTotalAmount;
        public decimal PurchaseTotalAmount
        {
            get { return _purchaseTotalAmount; }
            set { SetProperty(ref _purchaseTotalAmount, value); }
        }
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

            FilterTxnHistory("0");            

            DateFilterCmd = new DelegateCommand<string>(FilterTxnHistory); 
        }

        private void FilterTxnHistory(string filterValue)
        {
            var dateFilter = DateTime.Today;
            if (string.Equals(filterValue, "1"))
            {
                DateTime now = DateTime.Now;
                dateFilter = new DateTime(now.Year, now.Month, 1);                
            }
            SaleTxnList = _saleTransaction.GetTransactionHistory(dateFilter);
            PurchaseTxnList = _purchaseTransaction.GetPurchaseTxnHistory(dateFilter);
            SetTotalAmount();
        }

        private void SetTotalAmount()
        {
            var saleTotal = 0.0m;
            var purchaseTotal = 0.0m;
            foreach (var item in SaleTxnList)
                saleTotal += item.TransactionTotal;
            SaleTotalAmount = saleTotal;
            foreach (var item in PurchaseTxnList)
                purchaseTotal += item.PurchaseTxnTotal;
            PurchaseTotalAmount = purchaseTotal;
        }
    }
}
