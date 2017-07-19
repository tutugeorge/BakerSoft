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
        protected double TransactionTotal { get; set; }
        protected double TransactionTaxTotal { get; set; }
        
        #endregion



        public virtual void Complete()
        {            
        }

        public virtual void AddItem(Product item)
        {
            
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
