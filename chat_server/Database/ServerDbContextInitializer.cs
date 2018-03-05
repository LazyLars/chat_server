using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace chat_server.Database
{
    public class ServerDbContextInitializer : SqliteDropCreateDatabaseWhenModelChanges<ServerDbContext>
    {
        public ServerDbContextInitializer(DbModelBuilder modelBuilder)
            :base(modelBuilder)
        { }

        protected override void Seed(ServerDbContext context)
        {
            base.Seed(context);
        }
    }
}
