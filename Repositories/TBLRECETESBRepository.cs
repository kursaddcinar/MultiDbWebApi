using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLRECETESBRepository : ITBLRECETESBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLRECETESBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLRECETESB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Recetesb
                .FromSqlInterpolated($"EXEC FPROCRCLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
