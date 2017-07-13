using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTBill.Definitions
{
    interface ITransaction
    {
        void Complete();
        void Update();
        void Cancel();

        void AddItem();
        void AddTender();
        void CalculateTotal();
    }
}
