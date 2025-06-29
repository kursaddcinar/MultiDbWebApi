using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLCEKSENETRepository : ITBLCEKSENETRepository
    {
        private readonly FerpexDbContext _context;

        public TBLCEKSENETRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLCEKSENET>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Ceksenet
                .FromSqlInterpolated($"EXEC FPROCCSLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
