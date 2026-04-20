using Microsoft.EntityFrameworkCore;
using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Movies.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AbcSoftMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AbcSoftMoviesContext>>());

            if (context == null || context.Movies == null)
            {
                throw new NullReferenceException(
                    "Null AbcSoftMoviesContext or Movies DbSet");
            }

            if (context.Movies.Any())
            {
                return;
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title = "Mad Max",
                    ReleaseDate = new DateTime(1979, 4, 12),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.51M,
                },
                new Movie
                {
                    Title = "The Road Warrior",
                    ReleaseDate = new DateTime(1981, 12, 24),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.78M,
                },
                new Movie
                {
                    Title = "Mad Max: Beyond Thunderdome",
                    ReleaseDate = new DateTime(1985, 7, 10),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 3.55M,
                },
                new Movie
                {
                    Title = "Mad Max: Fury Road",
                    ReleaseDate = new DateTime(2015, 5, 15),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 8.43M,
                },
                new Movie
                {
                    Title = "Furiosa: A Mad Max Saga",
                    ReleaseDate = new DateTime(2024, 5, 24),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 13.49M,
                });

            context.SaveChanges();
        }
    }
}
