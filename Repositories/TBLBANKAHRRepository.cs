using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLBANKAHRRepository : ITBLBANKAHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLBANKAHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLBANKAHR>> ExecuteStoredProcedureAsync(string DatabaseName, string DetayTur, string BankaKod)
        {
            return await _context.Bankahr
                .FromSqlInterpolated($"EXEC FPROCBANKLIST {DatabaseName},{DetayTur},{BankaKod}")
                .ToListAsync();
        }
    }
}
