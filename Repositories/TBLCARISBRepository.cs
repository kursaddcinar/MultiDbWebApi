using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLCARISBRepository : ITBLCARISBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLCARISBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLCARISB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Carisb
                .FromSqlInterpolated($"EXEC FPROCCURLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
