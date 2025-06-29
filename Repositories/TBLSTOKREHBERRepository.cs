using MultiDbWebApi.Data;
using MultiDbWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiDbWebApi.Repositories
{
    public class TBLSTOKREHBERRepository : ITBLSTOKREHBERRepository
    {
        private readonly FerpexDbContext _context;

        public TBLSTOKREHBERRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLSTOKREHBER>> ExecuteStoredProcedureAsync(string DatabaseName,string gelen)
        {
            return await _context.Stokrehber
                .FromSqlInterpolated($"EXEC ZZFPROCSTOKREHBER {DatabaseName},{gelen}")
                .ToListAsync();
        }
    }
}