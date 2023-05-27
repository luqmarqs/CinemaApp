using System.ComponentModel.DataAnnotations;

namespace CinemaApp
{
    public class Filme
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600)]
        public int Duracao { get; set; }
    }
}