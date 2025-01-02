using System.Data.Entity;

namespace Movie_MVC.Models
{
    public class MoviesDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}