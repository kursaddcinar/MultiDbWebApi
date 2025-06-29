using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLISEMRIHRRepository : ITBLISEMRIHRRepository
    {
        private readonly FerpexDbContext _context;

        public TBLISEMRIHRRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLISEMRIHR>> ExecuteStoredProcedureAsync(string DatabaseName, string IsEmriKod)
        {
            return await _context.Isemrihr
                .FromSqlInterpolated($"EXEC FPROCPRES {DatabaseName},{IsEmriKod}")
                .ToListAsync();
        }
    }
}
