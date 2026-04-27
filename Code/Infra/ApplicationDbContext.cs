using Abc.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abc.Soft.Movies.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
