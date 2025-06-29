using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLSTOKHRRepository : ITBLSTOKHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLSTOKHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLSTOKHR>> ExecuteStoredProcedureAsync(string DatabaseName, string StokKod)
        {
            return await _context.Stokhr
                .FromSqlInterpolated($"EXEC FPROCSTLISTM {DatabaseName},{StokKod}")
                .ToListAsync();
        }
    }
}
