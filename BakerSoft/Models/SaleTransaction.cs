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

        public SaleTransaction(SaleTransactionRepository saleTransactionRepository)
        {
            _saleTransactionRepository = saleTransactionRepository;
        }

        public override void Complete()
       {
            base.Complete();
            //Call Data Layer
            _saleTransactionRepository.InsertTransaction();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        public override void AddItem(Item item)
        {
            base.AddItem(item);
            ItemList.Add(item as SaleItem);
        }
    }
}
