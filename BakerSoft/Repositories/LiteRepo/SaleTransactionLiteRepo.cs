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
