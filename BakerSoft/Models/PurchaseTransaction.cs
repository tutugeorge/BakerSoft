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
    class PurchaseTransaction : Transaction
    {
        private ITransactionRepository _transactionRepository;

        public List<Product> ItemList
        {
            get;
            set;
        }
        public List<Payment> PaymentList { get; set; }

        public PurchaseTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public override void Complete()
        {
            base.Complete();
        }

        public override void AddItem(Product item)
        {
            base.AddItem(item);
            ItemList.Add(item);
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        
    }
}
