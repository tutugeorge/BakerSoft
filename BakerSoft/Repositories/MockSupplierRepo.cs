using BakerSoft.Definitions;
using BakerSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Repositories
{
    class MockSupplierRepo : ISupplierRepository
    {
        List<Supplier> _supplierList = new List<Supplier>()
        {
            new Supplier() { GSTIN="123456", Name = "Supplier1", Id = "1" }
        };

        public void AddSupplier(Supplier supplier)
        {
            supplier.Id = (new Random(1000)).Next().ToString();
            _supplierList.Add(supplier);
        }

        public void EditSupplier()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetSuppliers()
        {
            return _supplierList;
        }
    }
}
