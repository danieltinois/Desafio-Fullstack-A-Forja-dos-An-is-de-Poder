using System.ComponentModel.DataAnnotations;

namespace AnelPowerAPI.Models
{
    public class Anel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Poder { get; set; }
        [Required]
        public string Portador { get; set; }  // Portador do anel (Elfo, Anão, Homem, Sauron)
        [Required]
        public string ForjadoPor { get; set; }
        public string Imagem { get; set; }
    }
}
