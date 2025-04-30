using BookStoreApi.DBOperations;
using BookStoreApi.Entities;

namespace BookStoreApi.UnitTests.TestsSetup;

public static class Authors
{ 
    public static void AddAuthors(this BookStoreDbContext context)
    {
        context.Authors.AddRange(
            new Author { Name = "Author 1", Surname = "Surname 1" },
            new Author { Name = "Author 2", Surname = "Surname 2" },
            new Author { Name = "Author 3", Surname = "Surname 3" }
        );
    }
       
    
}