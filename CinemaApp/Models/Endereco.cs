using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }
        [Required]
        [Range(1,20000)]
        public int Numero { get; set; }

    }
}
