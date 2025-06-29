namespace MultiDbWebApi.Models
{
    public class TBLUsersRequestDto
    {
        public string kulAdi { get; set; } = string.Empty;
        public string kulSifre { get; set; } = string.Empty;
        public string extraParam { get; set; } = string.Empty;
    }
}
