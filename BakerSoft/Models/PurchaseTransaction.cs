using BakerSoft.Models;
using BakerSoft.Repositories;
using GSTBill.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class PurchaseTransactionModel //: Transaction
    {
        private IPurchaseTransactionRepository _transactionRepository;

        //public decimal PurchaseTaxTotal { get; set; }
        //public decimal PurchaseTxnTotal { get; set; }
        //public DateTime PurchaseDate { get; set; }
        //public string SupplierId { get; set; }
        //public string GSTIN { get; set; }
        //public string BillNumber { get; set; }
        //public List<Product> ItemList
        //{
        //    get;
        //    set;
        //}
        //public List<Payment> PaymentList { get; set; }

        public PurchaseTransactionModel(IPurchaseTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;            
        }

        public void Complete(PurchaseTransaction purchase)
        {            
            _transactionRepository.InsertTransaction(purchase);
        }

        public List<PurchaseTransaction> GetPurchaseTxnHistory(DateTime fromDate)
        {
            return _transactionRepository.GetTransactionHistory(fromDate);
        }

        //public override void AddItem(Product item)
        //{
        //    base.AddItem(item);
        //    ItemList.Add(item);
        //}

        //public override void Cancel()
        //{
        //    base.Cancel();
        //}

        
    }
}
