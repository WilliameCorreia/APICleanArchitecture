using System.ComponentModel.DataAnnotations;

namespace ApiCleanArchitecture.Domain.Entities
{
    public class CirculacaoInterna
    {
        public CirculacaoInterna()
        {
            Registro = new List<Registro>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Cliente { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        public string Tipo_documento { get; set; }
        [Required]
        public int Cd_estabelecimento { get; set; }
        [Required]
        public List<Registro> Registro { get; set; }
    }
}
