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
        public int TransactionStatus { get; set; }
        public double TransactionTotal { get; set; }
        public double TransactionTaxTotal { get; set; }
        public decimal TransactionDiscountTotal { get; set; }
        public List<Product> ItemList
        {
            get;
            set;
        }
        public ObservableCollection<Payment> PaymentList { get; set; }
    }
}
