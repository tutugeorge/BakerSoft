using GSTBill.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSTBill.Models;
using DAL.LiteDB;
using AutoMapper;
using DAL.Models;

namespace BakerSoft.Repositories
{
    class PurchaseTransactionLiteRepository : IPurchaseTransactionRepository
    {
        public void InsertTransaction(PurchaseTransaction purchase)
        {
            using (var db = new StoreDbContext())
            {
                PURCHASE_TRANSACTIONS prod = Mapper.Map<PURCHASE_TRANSACTIONS>(purchase);
                

                db.Set<PURCHASE_TRANSACTIONS>().Add(prod);
                db.SaveChanges();
            }
        }
    }
}
