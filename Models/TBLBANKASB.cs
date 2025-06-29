namespace MultiDbWebApi.Models
{
    public class TBLBANKASB
    {
        public int? SUBE_KODU { get; set; }
        public string? BANKA_KODU { get; set; } = string.Empty;
        public string? BANKA_ADI { get; set; } = string.Empty;
        public string? DOVIZ_TIPI { get; set; } = string.Empty;
        public string? KALAN_TUTAR { get; set; } = string.Empty;
        public string? KALAN_DOVIZ_TUTAR { get; set; } = string.Empty;
    }
}
