using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
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

        public TransactionsViewModel(IRegionManager regionManager,
                            SaleTransactionModel saleTransaction,
                            PurchaseTransactionModel purchaseTransaction)
        {
            _saleTransaction = saleTransaction;
            _purchaseTransaction = purchaseTransaction;

            SaleTxnList = _saleTransaction.GetTransactionHistory();
            PurchaseTxnList = _purchaseTransaction.GetPurchaseTxnHistory();
        }
    }
}
