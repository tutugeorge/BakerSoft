﻿using BakerSoft.Definitions;
using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
using log4net;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddPaymentViewModel : BaseViewModel
    {
        private static readonly ILog log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IRegionManager _regionManager;
        SaleTransactionModel _saleTransaction;

        public DelegateCommand<string> CashPaymentCmd { get; set; }         
        public string PaymentTotal { get; set; }
        private decimal _paymentAmount;
        public decimal PaymentAmount
        {
            get { return _paymentAmount; }
            set
            {
                SetProperty(ref _paymentAmount, value);
            }
        }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public AddPaymentViewModel(IRegionManager regionManager,
                                   SaleTransactionModel saleTransaction)
        {
            _regionManager = regionManager;
            _saleTransaction = saleTransaction;

            CashPaymentCmd = new DelegateCommand<string>(CashPayment);
            NotificationRequest = new InteractionRequest<INotification>();

            PaymentAmount = _saleTransaction.sale.TransactionTotal;
        }

        private void RaiseNotification(string title, string message)
        {
            this.NotificationRequest.Raise(
               new Notification { Content = message, Title = title });
        }

        private void CashPayment(string amount)
        {
            try
            {
                var cashPayment = new SalePayment()
                {
                    PaymentAmount = Convert.ToDecimal(amount)
                };
                cashPayment.Payment = new Payment()
                {
                    PaidAmount = Convert.ToDecimal(amount),
                    PaymentDate = DateTime.Today,
                    PaymentType = 1
                };
                var outstandingAmount = _saleTransaction.AddPayment(cashPayment);

                if (outstandingAmount < 0)
                    RaiseNotification("Info",
                        string.Format("Balance amount is {0}", (-1.0m * outstandingAmount)));

                if (outstandingAmount <= 0)
                    CompleteTransaction(outstandingAmount * -1.0m);
                

                PaymentAmount = outstandingAmount;

                log.Info(String.Format("Cash payment of {0} successfull", amount));
            }
            catch(Exception ex)
            {
                log.Error("Cash payment failed", ex);
            }
            finally
            {
               
            }
        }

        private void CompleteTransaction(decimal balanceAmount)
        {
            //Show balance amount
            //if (balanceAmount > 0)
            //    ;
            _saleTransaction.Complete();
            _regionManager.RequestNavigate("ContentRegion", "SaleView");

            //if (_saleTransaction.sale.TransactionStatus.Equals(TRANS_STATUS.COMPLETED))
            //{
            //    //Show balance amount
            //    //Navigate back to sale txn screen
               
            //}
        }

        
    }
}
