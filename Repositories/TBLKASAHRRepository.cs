using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLKASAHRRepository : ITBLKASAHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLKASAHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLKASAHR>> ExecuteStoredProcedureAsync(string DatabaseName, string KasaKod)
        {
            return await _context.Kasahr
                .FromSqlInterpolated($"EXEC FPROCCASELIST {DatabaseName},{KasaKod}")
                .ToListAsync();
        }
    }
}
