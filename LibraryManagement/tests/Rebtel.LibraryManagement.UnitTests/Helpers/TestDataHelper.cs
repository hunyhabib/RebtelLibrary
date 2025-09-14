namespace Rebtel.LibraryManagement.UnitTests.Helpers;

public static class TestDataHelper
{
    public static List<Book> GetSampleBooks()
    {
        return new List<Book>
        {
            new Book 
            { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                Title = "The Great Gatsby", 
                Author = "F. Scott Fitzgerald", 
                ISBN = "978-0-7432-7356-5", 
                PageCount = 180, 
                PublishedDate = new DateTime(1925, 4, 10), 
                CopiesAvailable = 3 
            },
            new Book 
            { 
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                Title = "To Kill a Mockingbird", 
                Author = "Harper Lee", 
                ISBN = "978-0-06-112008-4", 
                PageCount = 324, 
                PublishedDate = new DateTime(1960, 7, 11), 
                CopiesAvailable = 2 
            },
            new Book 
            { 
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), 
                Title = "1984", 
                Author = "George Orwell", 
                ISBN = "978-0-452-28423-4", 
                PageCount = 328, 
                PublishedDate = new DateTime(1949, 6, 8), 
                CopiesAvailable = 4 
            },
            new Book 
            { 
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), 
                Title = "Pride and Prejudice", 
                Author = "Jane Austen", 
                ISBN = "978-0-14-143951-8", 
                PageCount = 279, 
                PublishedDate = new DateTime(1813, 1, 28), 
                CopiesAvailable = 5 
            },
            new Book 
            { 
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), 
                Title = "The Catcher in the Rye", 
                Author = "J.D. Salinger", 
                ISBN = "978-0-316-76948-0", 
                PageCount = 277, 
                PublishedDate = new DateTime(1951, 7, 16), 
                CopiesAvailable = 3 
            },
            new Book 
            { 
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), 
                Title = "Lord of the Flies", 
                Author = "William Golding", 
                ISBN = "978-0-571-05686-2", 
                PageCount = 224, 
                PublishedDate = new DateTime(1954, 9, 17), 
                CopiesAvailable = 2 
            },
            new Book 
            { 
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), 
                Title = "The Hobbit", 
                Author = "J.R.R. Tolkien", 
                ISBN = "978-0-547-92822-7", 
                PageCount = 366, 
                PublishedDate = new DateTime(1937, 9, 21), 
                CopiesAvailable = 6 
            },
            new Book 
            { 
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), 
                Title = "Brave New World", 
                Author = "Aldous Huxley", 
                ISBN = "978-0-06-085052-4", 
                PageCount = 268, 
                PublishedDate = new DateTime(1932, 8, 30), 
                CopiesAvailable = 4 
            }
        };
    }

    public static List<User> GetSampleUsers()
    {
        var books = GetSampleBooks();
        
        return new List<User>
        {
            new User 
            { 
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 
                Name = "John Doe", 
                Email = "john@example.com", 
                PhoneNumber = "123-456-7890", 
                MembershipDate = DateTime.Now.AddYears(-1),
                BorrowRecords = new List<BorrowRecord>
                {
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                        Books = new List<Book> { books[0], books[1] },
                        BorrowDate = DateTime.Now.AddDays(-30), 
                        ReturnDate = DateTime.Now.AddDays(-23) 
                    },
                    new BorrowRecord
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                        Books = new List<Book> { books[0], books[1] },
                        BorrowDate = DateTime.Now.AddDays(-50),
                        ReturnDate = DateTime.Now.AddDays(-40)
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), 
                        Books = new List<Book> { books[4], books[5] },
                        BorrowDate = DateTime.Now.AddDays(-40), 
                        ReturnDate = DateTime.Now.AddDays(-33) 
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 
                        Books = new List<Book> { books[2] },
                        BorrowDate = DateTime.Now.AddDays(-60), 
                        ReturnDate = DateTime.Now.AddDays(-55) 
                    }
                }
            },
            new User 
            { 
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 
                Name = "Jane Smith", 
                Email = "jane@example.com", 
                PhoneNumber = "098-765-4321", 
                MembershipDate = DateTime.Now.AddMonths(-6),
                BorrowRecords = new List<BorrowRecord>
                {
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                        Books = new List<Book> { books[0] },
                        BorrowDate = DateTime.Now.AddDays(-25), 
                        ReturnDate = DateTime.Now.AddDays(-18) 
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), 
                        Books = new List<Book> { books[3], books[6] },
                        BorrowDate = DateTime.Now.AddDays(-50), 
                        ReturnDate = DateTime.Now.AddDays(-43)
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), 
                        Books = new List<Book> { books[7], books[5] },
                        BorrowDate = DateTime.Now.AddDays(-65), 
                        ReturnDate = DateTime.Now.AddDays(-58) 
                    }
                }
            },
            new User 
            { 
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), 
                Name = "Alice Johnson", 
                Email = "alice@example.com", 
                PhoneNumber = "555-123-4567", 
                MembershipDate = DateTime.Now.AddMonths(-8),
                BorrowRecords = new List<BorrowRecord>
                {
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), 
                        Books = new List<Book> { books[2], books[3] },
                        BorrowDate = DateTime.Now.AddDays(-35), 
                        ReturnDate = DateTime.Now.AddDays(-28) 
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), 
                        Books = new List<Book> { books[7] },
                        BorrowDate = DateTime.Now.AddDays(-15), 
                        ReturnDate = DateTime.Now.AddDays(-8) 
                    }
                }
            },
            new User 
            { 
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), 
                Name = "Bob Wilson", 
                Email = "bob@example.com", 
                PhoneNumber = "555-987-6543", 
                MembershipDate = DateTime.Now.AddYears(-2),
                BorrowRecords = new List<BorrowRecord>
                {
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), 
                        Books = new List<Book> { books[0], books[2] },
                        BorrowDate = DateTime.Now.AddDays(-10), 
                        ReturnDate = null 
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), 
                        Books = new List<Book> { books[1], books[4] },
                        BorrowDate = DateTime.Now.AddDays(-45), 
                        ReturnDate = DateTime.Now.AddDays(-38) 
                    }
                }
            },
            new User 
            { 
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), 
                Name = "Carol Brown", 
                Email = "carol@example.com", 
                PhoneNumber = "555-246-8135", 
                MembershipDate = DateTime.Now.AddMonths(-3),
                BorrowRecords = new List<BorrowRecord>
                {
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), 
                        Books = new List<Book> { books[6] },
                        BorrowDate = DateTime.Now.AddDays(-20), 
                        ReturnDate = DateTime.Now.AddDays(-15) 
                    },
                    new BorrowRecord 
                    { 
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 
                        Books = new List<Book> { books[0], books[6] },
                        BorrowDate = DateTime.Now.AddDays(-5), 
                        ReturnDate = null 
                    }
                }
            }
        };
    }

    public static List<BorrowRecord> GetSampleBorrowRecords()
    {
        var users = GetSampleUsers();
        var books = GetSampleBooks();

        var borrowRecords = new List<BorrowRecord>
        {
            // Record 1: John borrowed The Great Gatsby and To Kill a Mockingbird together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                User = users[0], 
                Books = new List<Book> { books[0], books[1] }, // Great Gatsby + To Kill a Mockingbird
                BorrowDate = DateTime.Now.AddDays(-30), 
                ReturnDate = DateTime.Now.AddDays(-1) 
            },
             new BorrowRecord
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                User = users[0],
                Books = new List<Book> { books[0], books[1] }, // Great Gatsby + To Kill a Mockingbird
                BorrowDate = DateTime.Now.AddDays(-50),
                ReturnDate = DateTime.Now.AddDays(-10)
            },
            // Record 2: Jane borrowed The Great Gatsby alone (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                User = users[1], 
                Books = new List<Book> { books[0] }, // Great Gatsby
                BorrowDate = DateTime.Now.AddDays(-25), 
                ReturnDate = DateTime.Now
            },
            // Record 3: Alice borrowed 1984 and Pride and Prejudice together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), 
                User = users[2], 
                Books = new List<Book> { books[2], books[3] }, // 1984 + Pride and Prejudice
                BorrowDate = DateTime.Now.AddDays(-35), 
                ReturnDate = DateTime.Now.AddDays(-15) 
            },
            // Record 4: Bob borrowed The Great Gatsby and 1984 together (still active)
            new BorrowRecord 
            { 
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), 
                User = users[3], 
                Books = new List<Book> { books[0], books[2] }, // Great Gatsby + 1984
                BorrowDate = DateTime.Now.AddDays(-10), 
                ReturnDate = null 
            },
            // Record 5: Carol borrowed The Hobbit alone (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), 
                User = users[4], 
                Books = new List<Book> { books[6] }, // The Hobbit
                BorrowDate = DateTime.Now.AddDays(-20), 
                ReturnDate = DateTime.Now.AddDays(-15) 
            },
            // Record 6: John borrowed The Catcher in the Rye and Lord of the Flies together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), 
                User = users[0], 
                Books = new List<Book> { books[4], books[5] }, // Catcher in the Rye + Lord of the Flies
                BorrowDate = DateTime.Now.AddDays(-40), 
                ReturnDate = DateTime.Now.AddDays(-33) 
            },
            // Record 7: Jane borrowed Pride and Prejudice and The Hobbit together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), 
                User = users[1], 
                Books = new List<Book> { books[3], books[6] }, // Pride and Prejudice + The Hobbit
                BorrowDate = DateTime.Now.AddDays(-50), 
                ReturnDate = DateTime.Now.AddDays(-43)
            },
            // Record 8: Alice borrowed Brave New World alone (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), 
                User = users[2], 
                Books = new List<Book> { books[7] }, // Brave New World
                BorrowDate = DateTime.Now.AddDays(-15), 
                ReturnDate = DateTime.Now.AddDays(-8) 
            },
            // Record 9: Bob borrowed To Kill a Mockingbird and The Catcher in the Rye together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), 
                User = users[3], 
                Books = new List<Book> { books[1], books[4] }, // To Kill a Mockingbird + Catcher in the Rye
                BorrowDate = DateTime.Now.AddDays(-45), 
                ReturnDate = DateTime.Now.AddDays(-38) 
            },
            // Record 10: Carol borrowed The Great Gatsby and The Hobbit together (still active)
            new BorrowRecord 
            { 
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 
                User = users[4], 
                Books = new List<Book> { books[0], books[6] }, // Great Gatsby + The Hobbit
                BorrowDate = DateTime.Now.AddDays(-5), 
                ReturnDate = null 
            },
            // Record 11: John borrowed 1984 alone (returned) - for additional frequency testing
            new BorrowRecord 
            { 
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 
                User = users[0], 
                Books = new List<Book> { books[2] }, // 1984
                BorrowDate = DateTime.Now.AddDays(-60), 
                ReturnDate = DateTime.Now.AddDays(-55) 
            },
            // Record 12: Jane borrowed Brave New World and Lord of the Flies together (returned)
            new BorrowRecord 
            { 
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), 
                User = users[1], 
                Books = new List<Book> { books[7], books[5] }, // Brave New World + Lord of the Flies
                BorrowDate = DateTime.Now.AddDays(-65), 
                ReturnDate = DateTime.Now.AddDays(-58) 
            }
        };

        // Set the User property on BorrowRecords within each user's collection
        foreach (var borrowRecord in borrowRecords)
        {
            var userBorrowRecord = borrowRecord.User.BorrowRecords.FirstOrDefault(br => br.Id == borrowRecord.Id);
            if (userBorrowRecord != null)
            {
                userBorrowRecord.User = borrowRecord.User;
            }
        }

        return borrowRecords;
    }

    public static List<BookDTO> GetSampleBookDTOs()
    {
        return new List<BookDTO>
        {
            new BookDTO(Guid.Parse("11111111-1111-1111-1111-111111111111"), "The Great Gatsby", "F. Scott Fitzgerald", "978-0-7432-7356-5", 180, new DateTime(1925, 4, 10), 3),
            new BookDTO(Guid.Parse("22222222-2222-2222-2222-222222222222"), "To Kill a Mockingbird", "Harper Lee", "978-0-06-112008-4", 324, new DateTime(1960, 7, 11), 2),
            new BookDTO(Guid.Parse("33333333-3333-3333-3333-333333333333"), "1984", "George Orwell", "978-0-452-28423-4", 328, new DateTime(1949, 6, 8), 4),
            new BookDTO(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Pride and Prejudice", "Jane Austen", "978-0-14-143951-8", 279, new DateTime(1813, 1, 28), 5),
            new BookDTO(Guid.Parse("55555555-5555-5555-5555-555555555555"), "The Catcher in the Rye", "J.D. Salinger", "978-0-316-76948-0", 277, new DateTime(1951, 7, 16), 3),
            new BookDTO(Guid.Parse("66666666-6666-6666-6666-666666666666"), "Lord of the Flies", "William Golding", "978-0-571-05686-2", 224, new DateTime(1954, 9, 17), 2),
            new BookDTO(Guid.Parse("77777777-7777-7777-7777-777777777777"), "The Hobbit", "J.R.R. Tolkien", "978-0-547-92822-7", 366, new DateTime(1937, 9, 21), 6),
            new BookDTO(Guid.Parse("88888888-8888-8888-8888-888888888888"), "Brave New World", "Aldous Huxley", "978-0-06-085052-4", 268, new DateTime(1932, 8, 30), 4)
        };
    }

    public static List<UserDTO> GetSampleUserDTOs()
    {
        return new List<UserDTO>
        {
            new UserDTO(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "John Doe", "john@example.com", "123-456-7890", DateTime.Now.AddYears(-1)),
            new UserDTO(Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Jane Smith", "jane@example.com", "098-765-4321", DateTime.Now.AddMonths(-6)),
            new UserDTO(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Alice Johnson", "alice@example.com", "555-123-4567", DateTime.Now.AddMonths(-8)),
            new UserDTO(Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Bob Wilson", "bob@example.com", "555-987-6543", DateTime.Now.AddYears(-2)),
            new UserDTO(Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Carol Brown", "carol@example.com", "555-246-8135", DateTime.Now.AddMonths(-3))
        };
    }
}
