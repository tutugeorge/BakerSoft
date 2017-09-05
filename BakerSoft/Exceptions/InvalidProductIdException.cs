using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerSoft.Exceptions
{
    class NoPurchasedProductException : Exception
    {
        public string ErrorTitle { get { return "Error"; } }
        public string ErrorMessage { get { return "No Purchase made for this product"; } }
    }
    class InvalidProductIdException : Exception
    {
        public string ErrorTitle { get { return "Error"; } }
        public string ErrorMessage { get { return "Invalid Product Id"; } }
    }
}
