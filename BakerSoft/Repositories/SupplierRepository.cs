using AutoMapper;
using BakerSoft.Definitions;
using BakerSoft.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Repositories
{
    class SupplierRepository : ISupplierRepository
    {
        public void AddSupplier(Supplier supplier)
        {
            using (var db = new StoreDB())
            {
                SUPPLIER sup = Mapper.Map<SUPPLIER>(supplier);                                

                db.SUPPLIERS.Add(sup);
                db.SaveChanges();
            }
        }

        public void EditSupplier()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetSuppliers()
        {
            using (var db = new StoreDB())
            {
                var query = (from b in db.SUPPLIERS
                             //where b.SupplierName.Contains(name)
                             select b);
                List<Supplier> suppliers = Mapper.Map<List<Supplier>>(query.ToList());
                return suppliers;
            }
        }
    }
}
