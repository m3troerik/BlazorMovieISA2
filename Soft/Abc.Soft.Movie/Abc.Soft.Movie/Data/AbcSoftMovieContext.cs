using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abc.Soft.Movie.Models;

namespace Abc.Soft.Movie.Data
{
    public class AbcSoftMovieContext : DbContext
    {
        public AbcSoftMovieContext (DbContextOptions<AbcSoftMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Abc.Soft.Movie.Models.Movie> Movie { get; set; } = default!;
    }
}
