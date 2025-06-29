using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiDbWebApi.Models
{
    public class TBLRECETESB
    {
        public int? REC_NO { get; set; }
        public string? STOK_KODU { get; set; } = string.Empty;
        public string? STOK_ADI { get; set; } = string.Empty;
        public string? ACIKLAMA { get; set; } = string.Empty;
        public string? MIKTAR { get; set; } = string.Empty;
        public string? OLCU_BR { get; set; } = string.Empty;
        public string? RECETE_BAS_TAR { get; set; } = string.Empty;
        public int? URT_DEPO_KODU { get; set; } 
        public string? URT_DEPO_ADI { get; set; } = string.Empty;
    }
}
