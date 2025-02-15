using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class NewMovieContext : DbContext
{
    public NewMovieContext(DbContextOptions<NewMovieContext> options) : base (options)
    { }    
    
    public DbSet<Movie> Movies { get; set; }
    
}