﻿using BakerSoft.Definitions;
using BakerSoft.Models;
using GSTBill.Models;
using GSTBill.ViewModels;
using log4net;
using Prism.Commands;
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
        SaleTransaction _saleTransaction;

        public DelegateCommand<string> CashPaymentCmd { get; set; }         
        public string PaymentTotal { get; set; }

        public AddPaymentViewModel(IRegionManager regionManager,
                                   SaleTransaction saleTransaction)
        {
            _regionManager = regionManager;
            _saleTransaction = saleTransaction;

            CashPaymentCmd = new DelegateCommand<string>(CashPayment);
        }

        private void CashPayment(string amount)
        {
            try
            {
                var cashPayment = new Payment()
                {
                    Amount = Convert.ToDouble(amount)
                };
                _saleTransaction.AddPayment(cashPayment);
                log.Info(String.Format("Cash payment of {0} successfull", amount));
            }
            catch(Exception ex)
            {
                log.Error("Cash payment failed", ex);
            }
            finally
            {
               if( _saleTransaction.TransactionStatus.Equals(TRANS_STATUS.COMPLETED))
                {
                    //Show balance amount
                    //Navigate back to sale txn screen
                    _regionManager.RequestNavigate("", "");
                }
            }
        }
    }
}
