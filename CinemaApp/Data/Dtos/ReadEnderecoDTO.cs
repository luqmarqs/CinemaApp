using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Dtos
{
    public class ReadEnderecoDTO
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public DateTime DataDaConsulta { get; set; } = DateTime.Now;
    }
}
