namespace MultiDbWebApi.Models
{
    public class TBLCARISB
    {
        public int? REC_NO { get; set; }
        public string? CARI_ADI { get; set; } = string.Empty;
        public string? CARI_KODU { get; set; } = string.Empty;
        public string? CARI_KISA_ISIM { get; set; } = string.Empty;
        public string? CARI_TIPI { get; set; } = string.Empty;
        public string? CARI_ADRES { get; set; } = string.Empty;
        public string? CARI_ILCE { get; set; } = string.Empty;
        public string? CARI_IL { get; set; } = string.Empty;
        public string? CARI_ULKE { get; set; } = string.Empty;
        public string? CARI_TELEFON { get; set; } = string.Empty;
        public string? CARI_EPOSTA { get; set; } = string.Empty;
        public string? CARI_PLASIYER_KODU { get; set; } = string.Empty;
        public string? ALACAK_TOPLAM { get; set; } = string.Empty;//DEC
        public string? BORC_TOPLAM { get; set; } = string.Empty;//DEC
        public string? BAKIYE { get; set; } = string.Empty;//DEC
        public string? BAKIYET { get; set; } = string.Empty;
    }
}
