namespace MultiDbWebApi.Models
{
    public class TBLStokhrRequestDto
    {
        public string DatabaseName { get; set; } = string.Empty;
        public string StokKod { get; set; } = string.Empty;
        public string HrVar { get; set; } = string.Empty;
    }
}
