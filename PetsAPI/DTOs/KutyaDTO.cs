using PetsAPI.Models;
namespace PetsAPI.DTOs
{
    public class KutyaDTO
    {
        public int id { get; set; }
        public string? nev { get; set; }
        public int eletkor { get; set; }
        public string? fajta { get; set; }
        public string? gazdaNev { get; set; }
    }
}
