using BakerSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class PurchaseTransaction
    {
        public decimal PurchaseTaxTotal { get; set; }
        public decimal PurchaseTxnTotal { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SupplierId { get; set; }
        public string GSTIN { get; set; }
        public string BillNumber { get; set; }
        public List<PurchaseProduct> ItemList = new List<PurchaseProduct>();

        public List<PurchasePayment> PaymentList = new List<PurchasePayment>();
    }

    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal? SellingPrice { get; set; }

    }
}
