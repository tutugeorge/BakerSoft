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
        public List<SaleTransaction> GetTransactionHistory(DateTime fromDate)
        {
            List<SaleTransaction> saleTxns;
            //DateTime fromDate = DateTime.Today;
            //DateTime toDate = DateTime.Today;
            using (var db = new StoreDbContext())
            {
                var query = from b in db.Set<SALE_TRANSACTIONS>()
                            where b.TransactionDate >= fromDate //&& 
                            orderby b.TransactionDate descending
                            select b;
                saleTxns = Mapper.Map<List<SaleTransaction>>(query);
            }
            return saleTxns;
        }

        public decimal GetStockCount(int productId, decimal sellingPrice)
        {
            decimal stockCount = 0;
            //How to check stock
            using (var db = new StoreDbContext())
            {
                //var query = from pp in db.Set<PURCHASE_PRODUCTS>()                            
                //            join sp in db.Set<SALES_PRODUCTS>()
                //            on new { pp.ProductId, pp.PurchasePrice } equals new { sp.ProductId, sp.PurchasePrice }
                //            where pp.ProductId == productId 
                //            select new { pp.ProductId, stock = pp.Quantity-sp.Quantity, pp.PurchasePrice};

                // SellingPrice to be changed to PurchasePrice. Purchase Price not updated in SALES_PRODUCTS 
                // UOM Conversions to be checked
                //Get purchase details for the product grouped by purchase price.
                var purchase = (from pp in db.Set<PURCHASE_PRODUCTS>()
                          where pp.ProductId == productId
                          select new { pp.ProductId, pp.Quantity, pp.SellingPrice, pp.PurchasePrice })
                         .GroupBy(s => new {
                             s.ProductId,
                             s.PurchasePrice,
                             s.SellingPrice })
                         .Select(r => new {
                             r.Key.ProductId,
                             r.Key.PurchasePrice,
                             r.Key.SellingPrice,
                             qty = r.Sum(x => x.Quantity) });
                //Get Sales details for the product grouped by purchase price. UOM conversion based on product UOM 
                var sales = (from sp in db.Set<SALES_PRODUCTS>()
                          join uom in db.Set<UOM_DEFINITION_MASTER>()
                          on sp.UoM equals uom.UoMId
                          where sp.ProductId == productId
                          select new { sp.ProductId, Quantity = sp.Quantity/uom.UoMConversionFactor, sp.SellingPrice, sp.PurchasePrice })
                         .GroupBy(s => new { s.ProductId, s.PurchasePrice })
                         .Select(r => new { r.Key.ProductId, r.Key.PurchasePrice, qty = r.Sum(x => x.Quantity) });

                var result = from purch in purchase.ToList()
                             join sale in sales.ToList()
                             on purch.PurchasePrice equals sale.PurchasePrice
                             select new { purch.PurchasePrice, stock = (purch.qty - sale.qty) };

                if (result.Where(o => o.PurchasePrice.Equals(sellingPrice)).ToList().Count != 0)
                    stockCount = result.Where(o => o.PurchasePrice.Equals(sellingPrice)).FirstOrDefault().stock;
                else
                    stockCount = purchase.First(o => o.PurchasePrice.Equals(sellingPrice)).qty;
            }
            
            return stockCount;
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
