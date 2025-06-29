using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiDbWebApi.Models
{
    public class TBLRECETEHR
    {
        public string? RECETE_KODU { get; set; } = string.Empty;
        public string? STOK_KODU { get; set; } = string.Empty;
        public string? STOK_ADI { get; set; } = string.Empty;
        public string? GCKOD { get; set; } = string.Empty;
        public string? MIKTAR { get; set; } = string.Empty;
        public string? OLCU_BR { get; set; } = string.Empty;
        public int? DEPO_KODU { get; set; }
        public string? DEPO_ADI { get; set; } = string.Empty;
        public string? ACIKLAMA { get; set; } = string.Empty;
    }
}
