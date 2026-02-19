using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abc.Soft.Movies.Models;

namespace Abc.Soft.Movies.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Abc.Soft.Movies.Models.Movie> Movie { get; set; }
    }
}
