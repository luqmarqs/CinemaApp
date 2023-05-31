using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Dtos
{
    public class CreateEnderecoDTO
    {
        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }
        [Required]
        [Range(1, 20000)]
        public int Numero { get; set; }
    }
}
