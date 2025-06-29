using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLUSERSRepository : ITBLUSERSRepository
    {
        private readonly FerpexDbContext _context;

        public TBLUSERSRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLUSERS>> ExecuteStoredProcedureAsync(string kulAdi, string kulSifre, string extraParam)
        {
            return await _context.Users
                .FromSqlInterpolated($"EXEC FPROCUSCONCLO {kulAdi}, {kulSifre}, {extraParam}")
                .ToListAsync();
        }
    }
}
