using System.ComponentModel.DataAnnotations;

namespace XMLClientsList.Data
{
    public class Client
    {
        [Key]
        public int RegistratorID { get; set; }
        public string? FIO { get; set; }
        public int? RegNumber { get; set; }
        public long? DiasoftID { get; set; }
        public string? Registrator { get; set; }
    }
}