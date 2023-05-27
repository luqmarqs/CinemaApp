using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class FilmesContext : DbContext 
    {
        public FilmesContext(DbContextOptions<FilmesContext> opts) : base(opts) 
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
