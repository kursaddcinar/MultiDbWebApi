using System.Threading.Tasks;

namespace MultiDbWebApi.Models
{
    public class TBLURETIM
    {
        public string? SIPARIS_BELGE_NO { get; set; } = string.Empty;
        public string? SIPARIS_EVRAK_NO { get; set; } = string.Empty;
        public string? SIPARIS_CARI_KOD { get; set; } = string.Empty;
        public string? SIPARIS_CARI_ADI { get; set; } = string.Empty;
        public DateTime? SIPARIS_TARIH { get; set; } = null;
        public string? ISEMRI_BELGE_NO { get; set; } = string.Empty;
        public string? EVRAK_NO { get; set; } = string.Empty;
        public DateTime? ISEMRI_TARIH { get; set; } = null;
        public DateTime? ISEMRI_TESLIM_TARIHI { get; set; } = null;
        
        public decimal? ISEMRI_MIKTAR { get; set; } = 0m;
        public int? ISEMRI_STOK_KODU_RECID { get; set; }
        //----
        public string? ISEMRI_ACIKLAMA { get; set; } = string.Empty;
        public int? SIPARIS_RECNO { get; set; }
        public int? SIPARIS_KALEM_NO { get; set; } 
        public int? ISEMRI_KAPAT { get; set; } = null;
        //----
        public string? ISEMRI_STOK_KODU { get; set; } = string.Empty;
        public string? ISEMRI_STOK_ADI { get; set; } = string.Empty;
        public decimal? KALAN_MIKTAR { get; set; } = 0m;
        public int? ISEMRI_DURUM { get; set; } = null;
        public string? ACIK_DEPOLAR { get; set; } = null;
        public string? ISEMRI_RECETE_KODU { get; set; } = null;
        public string? ISEMRI_RECETE_ACIKLAMA { get; set; } = string.Empty;
        public int? SUBE_KODU { get; set; }
        public string? IE_KONTROL_KODU { get; set; } = null;
        public string? IE_PROJE_KODU { get; set; } = string.Empty;
        public string? IE_PROJE_ADI { get; set; } = string.Empty;
        public string? IE_PLASIYER_KODU { get; set; } = null;
        
        public int? RECETE_KODU_RECID { get; set; }
        public string? IE_OPR_DEPO_KODU { get; set; } = null;
        public int? OPERASYON_RECID { get; set; }
        public string? OPERASYON_KODU { get; set; } = string.Empty;
        public string? OPERASYON_ADI { get; set; } = string.Empty;
        public int? MAKINE_RECID { get; set; }
        public string? MAKINE_KODU { get; set; } = string.Empty;
        public string? MAKINE_ADI { get; set; } = string.Empty;
        public string? OPERASYON_EKLEME_YERI { get; set; } = string.Empty;
        public int? OPRMAKKUL_RECID { get; set; }
        public int? OPR_SIRA { get; set; } 
        public decimal? URETILEN_MIKTAR { get; set; } = 0m;
        public int? RECETEHR_RECNO { get; set; }
        public decimal? BILESEN_MIKTAR { get; set; } = 0m;
        public int? IE_RECNO { get; set; }
        public string? ACIKLAMA { get; set; } = null;
        public int? ISEMRI_SIRA { get; set; }
        public int? DEPO_KODU { get; set; }
        public decimal? KABUL_MIK { get; set; } = 0m;
        public decimal? RED_MIK { get; set; } = 0m;
        public decimal? URETILEBILIR_MIKTAR { get; set; } = 0m;
        //ısemeri_Stokkodrecid,siparisrecno,sipariskalemno,subekodu,recetekodurecid,operasyonrkodu,makinerecid,oprmakkulrecid,opr_sıra,recetehr_recno,ir_recno,isemris_sıra,depokodu
        
    }
}
