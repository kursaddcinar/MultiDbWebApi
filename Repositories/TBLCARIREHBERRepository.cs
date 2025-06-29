using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLCARIREHBERRepository : ITBLCARIREHBERRepository
    {
        private readonly FerpexDbContext _context;

        public TBLCARIREHBERRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLCARIREHBER>> ExecuteStoredProcedureAsync(string DatabaseName,string gelen)
        {
            return await _context.Carirehber
                .FromSqlInterpolated($"EXEC ZZFPROCCARIREHBER {DatabaseName},{gelen}")
                .ToListAsync();
        }
    }
}
