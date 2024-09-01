using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AtendoCloudSystem.EntityFrameworkCore
{
    public static class AtendoCloudSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AtendoCloudSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AtendoCloudSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
