using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLISEMRISBRepository : ITBLISEMRISBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLISEMRISBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLISEMRISB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Isemrisb
                .FromSqlInterpolated($"EXEC FPROCOPLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
