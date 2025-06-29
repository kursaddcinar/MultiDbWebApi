using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLDEPOSBRepository : ITBLDEPOSBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLDEPOSBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLDEPOSB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Deposb
                .FromSqlInterpolated($"EXEC FPROCDEPLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
