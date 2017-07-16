using BakerSoft.Models;
using BakerSoft.Repositories;
using GSTBill.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Models
{
    class SaleTransaction : Transaction
    {
        private SaleTransactionRepository _saleTransactionRepository;
        

        public ObservableCollection<SaleItem> ItemList { get; set; }
        public ObservableCollection<Payment> PaymentList { get; set; }

        public SaleTransaction(SaleTransactionRepository saleTransactionRepository)
        {
            _saleTransactionRepository = saleTransactionRepository;            
        }

        public void AddPayment(Payment payment)
        {
            PaymentList.Add(payment);
        }

        public override void Complete()
        {
            base.Complete();
            //Call Data Layer
            _saleTransactionRepository.InsertTransaction();
            ClearTransaction();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Cancel()
        {
            base.Cancel();
            ClearTransaction();
        }

        public override void AddItem(Item item)
        {
            base.AddItem(item);
            ItemList.Add(item as SaleItem);
        }

        public void RemoveItem(Item item)
        {
            //TODO : Remove selected item from the list
            ItemList.Remove(item as SaleItem);
        }

        private void ClearTransaction()
        {
            ItemList.Clear();
        }
    }
}
