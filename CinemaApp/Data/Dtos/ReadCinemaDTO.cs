namespace CinemaApp.Data.Dtos
{
    public class ReadCinemaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
