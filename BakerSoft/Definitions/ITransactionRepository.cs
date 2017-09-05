﻿using BakerSoft.Models;
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
        List<SaleTransaction> GetTransactionHistory(DateTime fromDate);
        void InsertTransaction(SaleTransaction sale);
        int GetStockCount(int productId);
    }

    interface IPurchaseTransactionRepository
    {
        List<PurchaseTransaction> GetTransactionHistory(DateTime dateFilter);
        void InsertTransaction(PurchaseTransaction purchase);
    }
}
