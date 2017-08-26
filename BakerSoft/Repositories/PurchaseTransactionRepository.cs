using GSTBill.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;
using DAL.Models;
using AutoMapper;

namespace BakerSoft.Repositories
{
    class PurchaseTransactionRepository : IPurchaseTransactionRepository
    {
        public void InsertTransaction(PurchaseTransaction purchase)
        {
            using (var db = new StoreDB())
            {
                PURCHASE_TRANSACTIONS prod = Mapper.Map<PURCHASE_TRANSACTIONS>(purchase);


                db.Set<PURCHASE_TRANSACTIONS>().Add(prod);
                db.SaveChanges();
            }
        }
    }
}
