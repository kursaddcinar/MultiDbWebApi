using Microsoft.EntityFrameworkCore;

namespace MultiDbWebApi.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options) { }

        // Burada gerekli DbSet'leri tanımlayabilirsiniz
    }
}
