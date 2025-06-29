namespace MultiDbWebApi.Models
{
    public class TBLKASAHR
    {
        public string? KASA_KODU { get; set; } = string.Empty;
        public string? KASA_ADI { get; set; } = string.Empty;
        public int? SUBE_KODU { get; set; }
        public string? SUBE_ADI { get; set; } = string.Empty;
        public string? TARIH { get; set; } = string.Empty;
        public string? EVRAK_NO { get; set; } = string.Empty;
        public string? ISLEM_ADI { get; set; } = string.Empty;
        public string? CMBK_ISIM { get; set; } = string.Empty;
        public string? GCKOD { get; set; } = string.Empty;
        public string? GIREN_TUTAR { get; set; } = string.Empty;
        public string? CIKAN_TUTAR { get; set; } = string.Empty;
        public string? TUTAR { get; set; } = string.Empty;
        public string? DOVIZ_TUTAR { get; set; } = string.Empty;
        public string? DOVIZ_TIPI { get; set; } = string.Empty;
        public string? DOVIZ_KUR { get; set; } = string.Empty;
        public string? KASA_ACIKLAMA { get; set; } = string.Empty;
    }
}
