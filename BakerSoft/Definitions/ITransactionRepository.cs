using BakerSoft.Models;
using GSTBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Definitions
{
    interface ITransactionRepository
    {
        void InsertTransaction();
    }

    interface ISaleTransactionRepository
    {
        void InsertTransaction(SaleTransaction sale);
    }

    interface IPurchaseTransactionRepository
    {
        void InsertTransaction(PurchaseTransaction purchase);
    }
}
