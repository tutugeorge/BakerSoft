using AutoMapper;
using BakerSoft.Models;
using DAL.LiteDB;
using DAL.Models;
using GSTBill.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Repositories
{
    class SaleTransactionLiteRepo : ISaleTransactionRepository
    {
        public List<SaleTransaction> GetTransactionHistory()
        {
            List<SaleTransaction> saleTxns;
            using (var db = new StoreDbContext())
            {
                var query = from b in db.Set<SALE_TRANSACTIONS>()
                            orderby b.TransactionDate descending
                            select b;
                saleTxns = Mapper.Map<List<SaleTransaction>>(query);
            }
            return saleTxns;
        }

        public int GetStockCount(int productId)
        {
            //How to check stock
            //using(var db = new StoreDbContext())
            //{
                
            //}
            return 1;
        }

        public void InsertTransaction(SaleTransaction sale)
        {
            using (var db = new StoreDbContext())
            {
                SALE_TRANSACTIONS prod = Mapper.Map<SALE_TRANSACTIONS>(sale);


                db.Set<SALE_TRANSACTIONS>().Add(prod);
                db.SaveChanges();
            }
        }
    }
}
