using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLBANKASBRepository : ITBLBANKASBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLBANKASBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLBANKASB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Bankasb
                .FromSqlInterpolated($"EXEC FPROCBANKLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
