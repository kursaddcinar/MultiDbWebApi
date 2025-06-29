using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLCARIHRRepository : ITBLCARIHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLCARIHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLCARIHR>> ExecuteStoredProcedureAsync(string DatabaseName, string CariKod)
        {
            return await _context.Carihr
                .FromSqlInterpolated($"EXEC FPROCCURLISTM {DatabaseName},{CariKod}")
                .ToListAsync();
        }
    }
}
