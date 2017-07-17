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

        public decimal TransactionDiscountTotal { get; set; }
        public List<Product> _itemList;
        public List<Product> ItemList
        {
            get { return _itemList; }
            set { SetProperty(ref _itemList, value); }
        }
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

        public override void AddItem(Product item)
        {
            base.AddItem(item);
            if (ItemList == null)
                ItemList = new List<Product>();
            ItemList.Add(item);
        }

        public void RemoveItem(Product item)
        {
            //TODO : Remove selected item from the list
            ItemList.Remove(item);
        }

        private void ClearTransaction()
        {
            ItemList.Clear();
        }
    }
}
