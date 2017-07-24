using GSTBill.Models;
using GSTBill.ViewModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddPurchaseViewModel : BaseViewModel
    {
        PurchaseTransaction _purchaseTransaction;

        public DelegateCommand PurchaseCmd { get; set; }

        public AddPurchaseViewModel(PurchaseTransaction purchaseTransaction)
        {
            _purchaseTransaction = purchaseTransaction;

            PurchaseCmd = new DelegateCommand(Purchase);
        }

        private void Purchase()
        {

        }
    }
}
