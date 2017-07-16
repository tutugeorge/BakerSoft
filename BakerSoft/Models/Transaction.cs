using GSTBill.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class Transaction : ITransaction
    {
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
