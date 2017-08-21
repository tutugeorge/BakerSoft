using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SQLite.CodeFirst;

namespace DAL.LiteDB
{
    public class StoreDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<StoreDbContext>
    {
        public StoreDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }

        protected override void Seed(StoreDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}