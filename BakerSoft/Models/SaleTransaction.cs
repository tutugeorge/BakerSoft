using GSTBill.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class SaleTransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionTotal { get; set; }
        public decimal TransactionTaxTotal { get; set; }
        public decimal TransactionDiscountTotal { get; set; }

        public int TransactionStatus { get; set; }
        public decimal ItemTotal { get; set; }

        public List<SaleProduct> ItemList
        {
            get;
            set;
        }
        public ObservableCollection<SalePayment> PaymentList { get; set; }
    }

    class SaleProduct
    {
        public int SaleTransactionId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public int UoM { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        //Additional
        public List<decimal?> PriceList { get; set; }

        public Tax ProductTax { get; set; }

        public string ProductDescription { get; set; }
    }

    class SalePayment
    {
        public int SaleTransactionId { get; set; }

        public int PaymentId { get; set; }

        public decimal PaymentAmount { get; set; }

        public Payment Payment { get; set; }
    }
}
