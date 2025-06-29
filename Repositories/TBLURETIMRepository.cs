using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLURETIMRepository : ITBLURETIMRepository
    {
        private readonly FerpexDbContext _context;

        public TBLURETIMRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLURETIM>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Uretim
                .FromSqlInterpolated($"EXEC FPROCPROLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
