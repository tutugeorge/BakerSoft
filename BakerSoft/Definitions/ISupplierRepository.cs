using BakerSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Definitions
{
    interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier );
        void GetSuppliers();
        void EditSupplier();
    }
}
