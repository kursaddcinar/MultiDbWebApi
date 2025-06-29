using MultiDbWebApi.Data;
using MultiDbWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiDbWebApi.Repositories
{
    public class TBLSTOKSBRepository : ITBLSTOKSBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLSTOKSBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLSTOKSB>> ExecuteStoredProcedureAsync(string DatabaseName )
        {
            return await _context.Stoksb
                .FromSqlInterpolated($"EXEC FPROCSTLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
