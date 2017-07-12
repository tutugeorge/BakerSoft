using GSTBill.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class SaleTransaction : Transaction
    {
        private SaleTransactionRepository _saleTransactionRepository;

        public SaleTransaction(SaleTransactionRepository saleTransactionRepository)
        {
            _saleTransactionRepository = saleTransactionRepository;
        }

        public override void Add()
       {
            base.Add();
            //Call Data Layer
            _saleTransactionRepository.InsertTransaction();
        }

        public override void Edit()
        {
            base.Edit();
        }

        public override void Delete()
        {
            base.Delete();
        }
    }
}
