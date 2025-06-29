using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Repositories
{
    public class TBLKALITEKONTROLRepository:ITBLKALITEKONTROLRepository
    {
        private readonly FerpexDbContext _context;

        public TBLKALITEKONTROLRepository(FerpexDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPanelKaliteAsync(TBLKALITEKONTROL PanelKaliteKontrol)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlInterpolatedAsync($@"EXEC FPROCPANELKKSAVE 
                        {PanelKaliteKontrol.DBNAME},
                        {PanelKaliteKontrol.KULLANICI_NO},
                        {PanelKaliteKontrol.PROJE_KODU},
                        {PanelKaliteKontrol.TARIH},
                        {PanelKaliteKontrol.KONTROLLAR_KODU},
                        {PanelKaliteKontrol.KONTROL1},
                        {PanelKaliteKontrol.KONTROL2},
                        {PanelKaliteKontrol.KONTROL3},
                        {PanelKaliteKontrol.KONTROL4},
                        {PanelKaliteKontrol.KONTROL5},
                        {PanelKaliteKontrol.KONTROL6},
                        {PanelKaliteKontrol.KONTROL7},
                        {PanelKaliteKontrol.KONTROL8},
                        {PanelKaliteKontrol.KONTROL9},
                        {PanelKaliteKontrol.KONTROL10},
                        {PanelKaliteKontrol.KONTROL11},
                        {PanelKaliteKontrol.KONTROL12},
                        {PanelKaliteKontrol.KONTROL13},
                        {PanelKaliteKontrol.KONTROL14},
                        {PanelKaliteKontrol.KONTROL15},
                        {PanelKaliteKontrol.KONTROL16},
                        {PanelKaliteKontrol.KONTROL17},
                        {PanelKaliteKontrol.KONTROL18},
                        {PanelKaliteKontrol.KONTROL19},
                        {PanelKaliteKontrol.KONTROL20},
                        {PanelKaliteKontrol.ACIKLAMA1},
                        {PanelKaliteKontrol.ACIKLAMA2},
                        {PanelKaliteKontrol.ACIKLAMA3}                      
                        ");

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
