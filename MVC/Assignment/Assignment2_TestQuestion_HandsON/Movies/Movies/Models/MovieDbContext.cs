using System.Data.Entity;

namespace Movies.Models
{
    public class MoviesDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}