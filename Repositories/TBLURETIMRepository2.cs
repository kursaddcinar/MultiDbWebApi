using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLURETIMRepository2 : ITBLURETIMRepository2
    {
        private readonly FerpexDbContext _context;

        public TBLURETIMRepository2(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLURETIM2>> ExecuteStoredProcedureAsync(string DatabaseName, string UretimKod)
        {
            return await _context.Uretim2
                .FromSqlInterpolated($"EXEC FPROCOPRLIST {DatabaseName},{UretimKod}")
                .ToListAsync();
        }
    }
}
