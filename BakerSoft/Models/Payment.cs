using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class Payment
    {
        public double Amount { get; set; }
    }

    class PurchasePayment
    {
        public int PurchaseId { get; set; }

        public int PaymentId { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}
