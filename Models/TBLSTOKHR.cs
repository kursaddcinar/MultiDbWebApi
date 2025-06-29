namespace MultiDbWebApi.Models
{
    public class TBLSTOKHR
    {
        public string? TARIH { get; set; } = string.Empty;
        public string? BELGE_ADI { get; set; } = string.Empty;
        public string? GIREN_MIKTAR { get; set; } = string.Empty;
        public string? CIKAN_MIKTAR { get; set; } = string.Empty;
        public string? BAKIYE { get; set; } = string.Empty;
        public string? KAYIT_ACIKLAMA { get; set; } = string.Empty;
        public string? STOK_NF { get; set; } = string.Empty;
        public string? TUTAR { get; set; } = string.Empty;
        public int? SUBE_KODU { get; set; }
        public string? CARI_ADI { get; set; } = string.Empty;
    }
}
