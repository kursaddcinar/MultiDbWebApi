using System.Data;
using System.Threading.Tasks;
using MultiDbWebApi.Models;
using MultiDbWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MultiDbWebApi.Repositories
{
    public class TBLURETIMKABULRepository : ITBLURETIMKABULRepository
    {
        private readonly string _connectionString;

        public TBLURETIMKABULRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FERPEXConnection");
        }

        public async Task<bool> ExecuteFPROCOPRSAVEAsync(TBLURETIMKABULRequestDto requestDto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FPROCOPRSAVE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@DBNAME", requestDto.DBNAME);
                    cmd.Parameters.AddWithValue("@ISEMRI_BELGE_NO", requestDto.ISEMRI_BELGE_NO);
                    cmd.Parameters.AddWithValue("@KULLANICI_NO", requestDto.KULLANICI_NO);
                    cmd.Parameters.AddWithValue("@DEPO_KODU", requestDto.DEPO_KODU);
                    cmd.Parameters.AddWithValue("@ISLEM_DK", requestDto.ISLEM_DK);
                    cmd.Parameters.AddWithValue("@ISLEM_TIPI", requestDto.ISLEM_TIPI);
                    cmd.Parameters.AddWithValue("@OPR_KODU_RECID", requestDto.OPR_KODU_RECID);
                    cmd.Parameters.AddWithValue("@MAK_KODU_RECID", requestDto.MAK_KODU_RECID);
                    cmd.Parameters.AddWithValue("@ISLEM_MIK", requestDto.ISLEM_MIK);
                    cmd.Parameters.AddWithValue("@KABUL_MIK", requestDto.KABUL_MIK);
                    cmd.Parameters.AddWithValue("@RED_MIK", requestDto.RED_MIK);
                    cmd.Parameters.AddWithValue("@RECETEHR_RECID", requestDto.RECETEHR_RECID);

                    // Bağlantıyı aç
                    await conn.OpenAsync();

                    // Satır sayısını al
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    // Sonucu değerlendir
                    if (rowsAffected > 0)
                    {
                        // En az bir satır eklendi
                        return true;
                    }
                    else
                    {
                        // Hiç satır etkilenmedi
                        return false;
                    }
                }
            }

        }
    }
}
