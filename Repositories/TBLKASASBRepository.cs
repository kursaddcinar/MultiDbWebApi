using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLKASASBRepository : ITBLKASASBRepository
    {
        private readonly FerpexDbContext _context;

        public TBLKASASBRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLKASASB>> ExecuteStoredProcedureAsync(string DatabaseName)
        {
            return await _context.Kasasb
                .FromSqlInterpolated($"EXEC FPROCKASLIST {DatabaseName}")
                .ToListAsync();
        }
    }
}
