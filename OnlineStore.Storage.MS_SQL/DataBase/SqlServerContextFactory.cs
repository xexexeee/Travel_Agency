using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OnlineStore.Storage.MS_SQL
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<Context>
    {
        private const string server = "Server=.;Database=Travel_Agency;  Integrated Security=true;TrustServerCertificate=true";

        public Context CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<Context>();
            optionBuilder.UseSqlServer(server, b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));
            return new Context(optionBuilder.Options);
        }
    }
}
