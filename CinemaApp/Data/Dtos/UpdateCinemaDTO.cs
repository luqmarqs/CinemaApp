using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Dtos
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
