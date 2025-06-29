namespace MultiDbWebApi.Models
{
    public class TBLCEKSENET
    {
        public int? EVRAK_TIPI { get; set; }
        public string? EVRAK_TIP_ADI { get; set; } = string.Empty;
        public int? SUBE_KODU { get; set; }
        public string? SUBE_ADI { get; set; } = string.Empty;
        public string? DURUMU { get; set; } = string.Empty;
        public string? YERI { get; set; } = string.Empty;
        public string? BANKA { get; set; } = string.Empty;
        public string? VEREN_ISIM { get; set; } = string.Empty;
        public string? ALAN_VEREN_ISIM { get; set; } = string.Empty;
        public string? VADE_TARIHI { get; set; } = string.Empty;
        public string? TUTAR { get; set; } = string.Empty;
        public string? ASIL_BORCLU { get; set; } = string.Empty;
        public string? SAHIBI { get; set; } = string.Empty;
        public string? ISLEM_ADI { get; set; } = string.Empty;
        public string? ISLEM_HESAP_ADI { get; set; } = string.Empty;
        public string? DOVIZ_TUTAR { get; set; } = string.Empty;
        public string? SERI_NO { get; set; } = string.Empty;
        public string? CEK_HESAP_NO { get; set; } = string.Empty;
        public int? VADE_GUN { get; set; }

    }
}
