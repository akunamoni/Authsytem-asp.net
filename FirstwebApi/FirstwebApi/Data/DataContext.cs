

using Microsoft.EntityFrameworkCore;

namespace FirstwebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }
        public DbSet<First> First { get; set; }
    }
}
