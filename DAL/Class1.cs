using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Class1
    {
        public void TestDBMethod()
        {
            using (var db = new StoreDB())
            {
                //db.PRODUCT_CATEGORY_MASTER.Add(new PRODUCT_CATEGORY_MASTER() { CategoryName="John Honai",CategoryDescription="This is my sample category"});
                //db.SaveChanges();
                var query = (from b in db.PRODUCT_CATEGORY_MASTER_NEW
                                       orderby b.CategoryName
                                       select b).FirstOrDefault();
                string y = query.CategoryName;
            }
        }
    }
}
