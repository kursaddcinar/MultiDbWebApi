using MultiDbWebApi.Data;
using MultiDbWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiDbWebApi.Repositories
{
    public class TBLSTOKSBRepository2 : ITBLSTOKSBRepository2
    {
        private readonly FerpexDbContext _context;

        public TBLSTOKSBRepository2(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBLSTOKSB2>> ExecuteStoredProcedureAsync(string DatabaseName, string StokKod)
        {
            return await _context.Stoksb2
                .FromSqlInterpolated($"EXEC ZZFPROCSTOKSB {DatabaseName},{StokKod}")
                .ToListAsync();
        }
    }
}
