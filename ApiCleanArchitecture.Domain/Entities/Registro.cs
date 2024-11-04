using System.ComponentModel.DataAnnotations;

namespace ApiCleanArchitecture.Domain.Entities
{
    public class Registro
    {
        public int ID { get; set; }
        [Required]
        public string Prestador { get; set; }
        [Required]
        public string Destino { get; set; }

        public DateTime Registro_date { get; set; }
    }
}
