using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Dtos
{
    public class CreateFilmeDTO
    {
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(50)]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600)]
        public int Duracao { get; set; }
    }
}
