using BakerSoft.Models;
using BakerSoft.Repositories;
using GSTBill.Definitions;
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
        private ITransactionRepository _saleTransactionRepository;

        public decimal TransactionDiscountTotal { get; set; }        
        public List<Product> ItemList
        {
            get;
            set;
        }
        public ObservableCollection<Payment> PaymentList { get; set; }

        public SaleTransaction(ITransactionRepository saleTransactionRepository)
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

            AddToTransactionTotal(item.PriceList[0]);
            AddToTaxTotal(item.ProductTax, item.PriceList[0]);
        }

        public void RemoveItem(Product item)
        {
            //TODO : Remove selected item from the list
            ItemList.Remove(item);
            SubstractFromTransactionTotal(item.PriceList[0]);
            SubstractFromTaxTotal(item.ProductTax, item.PriceList[0]);
        }

        private void AddToTaxTotal(Tax tax, Price price)
        {
            TransactionTaxTotal += (price.SellingPrice * tax.SGST) + 
                                    (price.SellingPrice * tax.CGST);
        }

        private void SubstractFromTaxTotal(Tax tax, Price price)
        {
            TransactionTaxTotal -= (price.SellingPrice * tax.SGST) +
                                    (price.SellingPrice * tax.CGST);
        }

        private void AddToTransactionTotal(Price price)
        {
            TransactionTotal += price.SellingPrice;
        }

        private void SubstractFromTransactionTotal(Price price)
        {
            TransactionTotal -= price.SellingPrice;
        }

        private void ClearTransaction()
        {
            ItemList.Clear();
            TransactionTotal = 0.00;
            TransactionTaxTotal = 0.00;
        }
    }
}
