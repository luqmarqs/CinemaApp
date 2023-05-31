using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório!")]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
