using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLRECETEHRRepository : ITBLRECETEHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLRECETEHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLRECETEHR>> ExecuteStoredProcedureAsync(string DatabaseName, string ReceteKod)
        {
            return await _context.Recetehr
                .FromSqlInterpolated($"EXEC FPROCRECSTCARD {DatabaseName},{ReceteKod}")
                .ToListAsync();
        }
    }
}
