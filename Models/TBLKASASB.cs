namespace MultiDbWebApi.Models
{
    public class TBLKASASB
    {
        public int? SUBE_KODU { get; set; }
        public string? KASA_KODU { get; set; } = string.Empty;
        public string? KASA_ADI { get; set; } = string.Empty;
        public string? DOVIZ_TIPI { get; set; } = string.Empty;
        public string? KALAN_TUTAR { get; set; } = string.Empty;
        public string? KALAN_DOVIZ_TUTAR { get; set; } = string.Empty;
    }
}
