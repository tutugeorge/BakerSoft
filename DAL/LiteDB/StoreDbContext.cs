using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;

namespace DAL.LiteDB
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("LiteDB")
        {
            Configure();
        }

        public StoreDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new StoreDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}
