using BakerSoft.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakerSoft.Models;
using DAL.LiteDB;
using DAL.Models;
using AutoMapper;

namespace BakerSoft.Repositories
{
    class SupplierLiteRepository : ISupplierRepository
    {
        public void AddSupplier(Supplier supplier)
        {
            using (var db = new StoreDbContext())
            {
                SUPPLIER sup = Mapper.Map<SUPPLIER>(supplier);

                db.Set<SUPPLIER>().Add(sup); 
                db.SaveChanges();
            }
        }

        public void EditSupplier()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
