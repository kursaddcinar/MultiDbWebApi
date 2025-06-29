using MultiDbWebApi.Data;
using MultiDbWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiDbWebApi.Repositories
{
    public class TBLDEPOSAYIMREHBERRepository : ITBLDEPOSAYIMREHBERRepository
    {
        private readonly FerpexDbContext _context;

        public TBLDEPOSAYIMREHBERRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLDEPOSAYIMREHBER>> ExecuteStoredProcedureAsync(string DatabaseName, string gelen)
        {
            return await _context.Deposayimrehber
                .FromSqlInterpolated($"EXEC FPROCDEPOSTOKLIST {DatabaseName},{gelen}")
                .ToListAsync();
        }
    }
}
