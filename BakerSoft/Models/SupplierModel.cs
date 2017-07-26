using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Models
{
    class SupplierModel
    {
        private ISupplierRepository _supplierRepository;
        public SupplierModel(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void AddSupplier()
        {
            _supplierRepository.AddSupplier();
        }

        public void GetSuppliers()
        {
            _supplierRepository.GetSuppliers();
        }
    }
}
