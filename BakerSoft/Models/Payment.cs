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

        public int PaymentId { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int PaymentType { get; set; }

    }

    class PurchasePayment
    {
        public int PurchaseId { get; set; }

        public int PaymentId { get; set; }

        public decimal PaymentAmount { get; set; }

        public Payment Payment { get; set; }
    }
}
