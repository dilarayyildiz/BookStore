using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.UnitTests.TestsSetup;

public static class Genres
{
    public static void AddGenres(this BookStoreDbContext context)
    {
        context.Genres.AddRange(
            new Genre { Name = "Personal Growth" },
            new Genre { Name = "Science Fiction" },
            new Genre { Name = "Romance" }
        );
    }
    
}