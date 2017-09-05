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

        private List<SaleTransaction> _saleTxnList;
        public List<SaleTransaction> SaleTxnList
        {
            get { return _saleTxnList; }
            set
            {
                SetProperty(ref _saleTxnList, value);
            }
        }

        public TransactionsViewModel(IRegionManager regionManager,
                            SaleTransactionModel saleTransaction)
        {
            _saleTransaction = saleTransaction;

            SaleTxnList = _saleTransaction.GetTransactionHistory();
        }
    }
}
