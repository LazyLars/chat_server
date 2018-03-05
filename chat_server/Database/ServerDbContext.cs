using chat_server.Database.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace chat_server.Database
{
    public class ServerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ServerDbContext()
            :base("default")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectioninitializer = new ServerDbContextInitializer(modelBuilder);
             
        }
    }
}
