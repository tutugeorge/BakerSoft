using BakerSoft.Models;
using GSTBill.ViewModels;
using log4net;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.ViewModels
{
    class AddSupplierViewModel : BaseViewModel
    {
        private static readonly ILog log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SupplierModel _supplierModel;

        private string _supplierName;
        public string SupplierName
        {
            get { return _supplierName; }
            set { SetProperty(ref _supplierName, value); }
        }
        private string _gstNumber;
        public string GstNumber
        {
            get { return _gstNumber; }
            set { SetProperty(ref _gstNumber, value); }
        }

        public DelegateCommand AddSupplierCmd { get; set; }

        public AddSupplierViewModel(SupplierModel supplierModel)
        {
            _supplierModel = supplierModel;
            AddSupplierCmd = new DelegateCommand(AddSupplier);
        }

        private void AddSupplier()
        {
            var supplier = new Supplier();
            try
            {
                supplier.GSTIN = GstNumber;
                supplier.Name = SupplierName;
                _supplierModel.AddSupplier(supplier);
                log.Info(String.Format("New Supplier {0} added successfully", SupplierName));
            }
            catch (Exception ex)
            {
                log.Error(supplier, ex);
            }
            finally
            {
                ResetUI();
            }
        }

        private void ResetUI()
        {
            GstNumber = "";
            SupplierName = "";
        }
    }
}
