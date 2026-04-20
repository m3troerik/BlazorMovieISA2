using Abc.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Infra;
public class AbcSoftMoviesContext(DbContextOptions<AbcSoftMoviesContext> options)
    : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<Currency> Currencies { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Money> Monies { get; set; } = default!;
    public DbSet<CountryCurrency> CountryCurrencies { get; set; } = default!;
}