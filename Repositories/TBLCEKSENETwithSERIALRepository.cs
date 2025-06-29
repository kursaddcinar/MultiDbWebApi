using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLCEKSENETwithSERIALRepository : ITBLCEKSENETwithSERIALRepository
    {
        private readonly FerpexDbContext _context;

        public TBLCEKSENETwithSERIALRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLCEKSENETwithSERIAL>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Ceksenetwithserial
                .FromSqlInterpolated($"EXEC FPROCCSLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
