using BakerSoft.Definitions;
using GSTBill.Definitions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class Transaction : BindableBase, ITransaction
    {
        #region Properties
        protected int TransactionId { get; set; }
        protected DateTime TransactionDate { get; set; }
        public double TransactionTotal { get; set; }
        public double TransactionTaxTotal { get; set; }
        public int TransactionStatus { get; set; } 
        #endregion



        public virtual void Complete()
        {
            TransactionStatus = TRANS_STATUS.COMPLETED;
        }

        public virtual void AddItem(Product item)
        {
            TransactionStatus = TRANS_STATUS.ACTIVE;
        }

        public void AddTender()
        {
            throw new NotImplementedException();
        }

        public void CalculateTotal()
        {
            throw new NotImplementedException();
        }

        public virtual void Cancel()
        {           
        }

        public virtual void Update()
        {            
        }
    }
}
