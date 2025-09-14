using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData
{
    internal static class BookSeedData
    {
        public static List<Book> Books =>
            new List<Book>
            {
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "978-0-06-112008-4",
                    PageCount = 324,
                    PublishedDate = new DateTime(1960, 7, 11),
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "978-0-452-28423-4",
                    PageCount = 328,
                    PublishedDate = new DateTime(1949, 6, 8),
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    ISBN = "978-0-14-143951-8",
                    PageCount = 432,
                    PublishedDate = new DateTime(1813, 1, 28),
                    CopiesAvailable = 4
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    ISBN = "978-0-7432-7356-5",
                    PageCount = 180,
                    PublishedDate = new DateTime(1925, 4, 10),
                    CopiesAvailable = 6
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    ISBN = "978-0-316-76948-0",
                    PageCount = 277,
                    PublishedDate = new DateTime(1951, 7, 16),
                    CopiesAvailable = 2
                },

                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111116"),
                    Title = "Dune",
                    Author = "Frank Herbert",
                    ISBN = "978-0-441-17271-9",
                    PageCount = 688,
                    PublishedDate = new DateTime(1965, 8, 1),
                    CopiesAvailable = 4
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111117"),
                    Title = "Foundation",
                    Author = "Isaac Asimov",
                    ISBN = "978-0-553-29335-6",
                    PageCount = 244,
                    PublishedDate = new DateTime(1951, 5, 1),
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111118"),
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    ISBN = "978-0-345-39180-3",
                    PageCount = 224,
                    PublishedDate = new DateTime(1979, 10, 12),
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                    Title = "Neuromancer",
                    Author = "William Gibson",
                    ISBN = "978-0-441-56956-9",
                    PageCount = 271,
                    PublishedDate = new DateTime(1984, 7, 1),
                    CopiesAvailable = 2
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                    Title = "Ender's Game",
                    Author = "Orson Scott Card",
                    ISBN = "978-0-812-55070-2",
                    PageCount = 324,
                    PublishedDate = new DateTime(1985, 1, 15),
                    CopiesAvailable = 4
                },

                // Fantasy
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-547-92822-7",
                    PageCount = 366,
                    PublishedDate = new DateTime(1937, 9, 21),
                    CopiesAvailable = 6
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                    Title = "The Fellowship of the Ring",
                    Author = "J.R.R. Tolkien",
                    ISBN = "978-0-547-92821-0",
                    PageCount = 479,
                    PublishedDate = new DateTime(1954, 7, 29),
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                    Title = "Harry Potter and the Philosopher's Stone",
                    Author = "J.K. Rowling",
                    ISBN = "978-0-7475-3269-9",
                    PageCount = 223,
                    PublishedDate = new DateTime(1997, 6, 26),
                    CopiesAvailable = 8
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                    Title = "A Game of Thrones",
                    Author = "George R.R. Martin",
                    ISBN = "978-0-553-10354-0",
                    PageCount = 694,
                    PublishedDate = new DateTime(1996, 8, 1),
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                    Title = "The Name of the Wind",
                    Author = "Patrick Rothfuss",
                    ISBN = "978-0-7564-0474-1",
                    PageCount = 662,
                    PublishedDate = new DateTime(2007, 3, 27),
                    CopiesAvailable = 3
                },

                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                    Title = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    ISBN = "978-0-307-45454-1",
                    PageCount = 590,
                    PublishedDate = new DateTime(2005, 8, 1),
                    CopiesAvailable = 4
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111127"),
                    Title = "Gone Girl",
                    Author = "Gillian Flynn",
                    ISBN = "978-0-307-58836-4",
                    PageCount = 419,
                    PublishedDate = new DateTime(2012, 6, 5),
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111128"),
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    ISBN = "978-0-307-47492-1",
                    PageCount = 489,
                    PublishedDate = new DateTime(2003, 3, 18),
                    CopiesAvailable = 5
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111129"),
                    Title = "And Then There Were None",
                    Author = "Agatha Christie",
                    ISBN = "978-0-06-207348-6",
                    PageCount = 264,
                    PublishedDate = new DateTime(1939, 11, 6),
                    CopiesAvailable = 4
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111130"),
                    Title = "The Big Sleep",
                    Author = "Raymond Chandler",
                    ISBN = "978-0-394-75828-5",
                    PageCount = 231,
                    PublishedDate = new DateTime(1939, 2, 6),
                    CopiesAvailable = 2
                },

                // Non-Fiction
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111131"),
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    ISBN = "978-0-062-31609-6",
                    PageCount = 443,
                    PublishedDate = new DateTime(2011, 1, 1),
                    CopiesAvailable = 6
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111132"),
                    Title = "Educated",
                    Author = "Tara Westover",
                    ISBN = "978-0-399-59050-4",
                    PageCount = 334,
                    PublishedDate = new DateTime(2018, 2, 20),
                    CopiesAvailable = 7
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111133"),
                    Title = "The Immortal Life of Henrietta Lacks",
                    Author = "Rebecca Skloot",
                    ISBN = "978-1-400-05217-2",
                    PageCount = 381,
                    PublishedDate = new DateTime(2010, 2, 2),
                    CopiesAvailable = 3
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111134"),
                    Title = "Thinking, Fast and Slow",
                    Author = "Daniel Kahneman",
                    ISBN = "978-0-374-53355-7",
                    PageCount = 499,
                    PublishedDate = new DateTime(2011, 10, 25),
                    CopiesAvailable = 4
                },
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111135"),
                    Title = "The Power of Habit",
                    Author = "Charles Duhigg",
                    ISBN = "978-1-400-06928-6",
                    PageCount = 371,
                    PublishedDate = new DateTime(2012, 2, 28),
                    CopiesAvailable = 5
                }
            };
    }
}