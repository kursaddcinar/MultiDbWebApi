namespace MultiDbWebApi.Models
{
    public class TBLURETIMKABULRequestDto
    {
        public string DBNAME { get; set; } = string.Empty; // Veritabanı adı
        public string ISEMRI_BELGE_NO { get; set; } = string.Empty; // İş emri belge numarası
        public int KULLANICI_NO { get; set; } = 0; // Kullanıcı numarası
        public int DEPO_KODU { get; set; } = 0; // Depo kodu
        public int ISLEM_DK { get; set; } = 0; // İşlem süresi (dakika)
        public int ISLEM_TIPI { get; set; } = 0; // İşlem tipi (Kabul: 0, Red: 1)
        public int OPR_KODU_RECID { get; set; } = 0; // Operatör kayıt ID
        public int MAK_KODU_RECID { get; set; } = 0; // Makine kayıt ID
        public double ISLEM_MIK { get; set; } = 0; // İşlem miktarı (Kabul veya Red miktarına eşit)
        public double KABUL_MIK { get; set; } = 0; // Kabul miktarı
        public double RED_MIK { get; set; } = 0; // Red miktarı
        public int RECETEHR_RECID { get; set; } = 0; // Reçete detay kayıt ID
    }
}
