using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData
{
    internal static class BorrowRecordSeedData
    {
        public static List<object> GetBorrowRecords()
        {
            return new List<object>
            {
                // 2022 Records
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000001"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222221"),
                    BorrowDate = new DateTime(2022, 1, 15),
                    ReturnDate = new DateTime(2022, 2, 10)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000002"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    BorrowDate = new DateTime(2022, 1, 20),
                    ReturnDate = new DateTime(2022, 2, 18)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000003"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    BorrowDate = new DateTime(2022, 2, 5),
                    ReturnDate = new DateTime(2022, 3, 1)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000004"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222224"),
                    BorrowDate = new DateTime(2022, 3, 12),
                    ReturnDate = new DateTime(2022, 4, 8)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000005"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    BorrowDate = new DateTime(2022, 4, 3),
                    ReturnDate = new DateTime(2022, 4, 25)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000006"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    BorrowDate = new DateTime(2022, 5, 18),
                    ReturnDate = new DateTime(2022, 6, 15)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000007"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222227"),
                    BorrowDate = new DateTime(2022, 6, 10),
                    ReturnDate = new DateTime(2022, 7, 8)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000008"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222228"),
                    BorrowDate = new DateTime(2022, 7, 22),
                    ReturnDate = new DateTime(2022, 8, 18)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000009"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222229"),
                    BorrowDate = new DateTime(2022, 8, 5),
                    ReturnDate = new DateTime(2022, 8, 28)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000010"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                    BorrowDate = new DateTime(2022, 9, 14),
                    ReturnDate = new DateTime(2022, 10, 12)
                },

                // 2023 Records
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000011"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222231"),
                    BorrowDate = new DateTime(2023, 1, 8),
                    ReturnDate = new DateTime(2023, 2, 5)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000012"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222232"),
                    BorrowDate = new DateTime(2023, 2, 20),
                    ReturnDate = new DateTime(2023, 3, 18)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000013"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222233"),
                    BorrowDate = new DateTime(2023, 3, 15),
                    ReturnDate = new DateTime(2023, 4, 10)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000014"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222234"),
                    BorrowDate = new DateTime(2023, 4, 12),
                    ReturnDate = new DateTime(2023, 5, 15)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000015"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222235"),
                    BorrowDate = new DateTime(2023, 5, 25),
                    ReturnDate = new DateTime(2023, 6, 22)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000016"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222236"),
                    BorrowDate = new DateTime(2023, 6, 18),
                    ReturnDate = new DateTime(2023, 7, 20)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000017"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222237"),
                    BorrowDate = new DateTime(2023, 7, 30),
                    ReturnDate = new DateTime(2023, 8, 25)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000018"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222238"),
                    BorrowDate = new DateTime(2023, 8, 14),
                    ReturnDate = new DateTime(2023, 9, 12)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000019"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222239"),
                    BorrowDate = new DateTime(2023, 9, 8),
                    ReturnDate = new DateTime(2023, 10, 5)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000020"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222240"),
                    BorrowDate = new DateTime(2023, 10, 22),
                    ReturnDate = new DateTime(2023, 11, 18)
                },

                // 2024 Records (including some still borrowed - no return date)
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000021"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222221"),
                    BorrowDate = new DateTime(2024, 1, 10),
                    ReturnDate = new DateTime(2024, 2, 8)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000022"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    BorrowDate = new DateTime(2024, 2, 15),
                    ReturnDate = new DateTime(2024, 3, 12)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000023"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    BorrowDate = new DateTime(2024, 3, 20),
                    ReturnDate = new DateTime(2024, 4, 18)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000024"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222224"),
                    BorrowDate = new DateTime(2024, 4, 25),
                    ReturnDate = new DateTime(2024, 5, 20)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000025"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    BorrowDate = new DateTime(2024, 5, 12),
                    ReturnDate = new DateTime(2024, 6, 10)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000026"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    BorrowDate = new DateTime(2024, 6, 18),
                    ReturnDate = new DateTime(2024, 7, 15)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000027"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222227"),
                    BorrowDate = new DateTime(2024, 7, 22),
                    ReturnDate = new DateTime(2024, 8, 20)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000028"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222228"),
                    BorrowDate = new DateTime(2024, 8, 30),
                    ReturnDate = new DateTime(2024, 9, 25)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000029"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222229"),
                    BorrowDate = new DateTime(2024, 9, 15),
                    ReturnDate = new DateTime(2024, 10, 12)
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000030"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                    BorrowDate = new DateTime(2024, 10, 20),
                    ReturnDate = new DateTime(2024, 11, 18)
                },

                // Current borrowings (no return date - still borrowed)
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000031"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222231"),
                    BorrowDate = new DateTime(2024, 11, 10),
                    ReturnDate = (DateTime?)null
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000032"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222232"),
                    BorrowDate = new DateTime(2024, 11, 18),
                    ReturnDate = (DateTime?)null
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000033"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222233"),
                    BorrowDate = new DateTime(2024, 12, 1),
                    ReturnDate = (DateTime?)null
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000034"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222234"),
                    BorrowDate = new DateTime(2024, 12, 8),
                    ReturnDate = (DateTime?)null
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-000000000035"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222235"),
                    BorrowDate = new DateTime(2024, 12, 15),
                    ReturnDate = (DateTime?)null
                }
            };
        }

        // Seed data for the many-to-many relationship between BorrowRecord and Books
        public static List<object> GetBorrowRecordBooks()
        {
            return new List<object>
            {
                // 2022 Records - Book relationships
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000001"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111123") }, // Harry Potter
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000002"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111131") }, // Sapiens
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000003"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111112") }, // 1984
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000003"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111111") }, // To Kill a Mockingbird
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000004"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111118") }, // Hitchhiker's Guide
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000005"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111121") }, // The Hobbit
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000006"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111132") }, // Educated
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000007"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111126") }, // Girl with Dragon Tattoo
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000008"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111115") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000009"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111123") }, // Harry Potter (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000010"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111119") },

                // 2023 Records - Book relationships
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000011"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111131") }, // Sapiens (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000012"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111117") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000013"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111118") }, // Hitchhiker's Guide
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000013"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111120") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000014"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111121") }, // The Hobbit (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000015"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111124") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000016"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111112") }, // 1984 (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000017"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111128") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000018"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111132") }, // Educated (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000019"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111129") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000020"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111126") }, // Girl with Dragon Tattoo (popular book)

                // 2024 Records - Book relationships
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000021"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111133") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000022"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111123") }, // Harry Potter (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000023"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111134") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000024"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111131") }, // Sapiens (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000025"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111135") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000026"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111121") }, // The Hobbit
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000026"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111122") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000027"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111118") }, // Hitchhiker's Guide (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000028"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111113") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000029"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111112") }, // 1984 (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000030"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111114") },

                // Current borrowings - Book relationships
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000031"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111132") }, // Educated (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000032"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111126") }, // Girl with Dragon Tattoo (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000033"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111116") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000034"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111123") }, // Harry Potter (popular book)
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000034"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111127") },
                new { BorrowRecordId = Guid.Parse("33333333-3333-3333-3333-000000000035"), BookId = Guid.Parse("11111111-1111-1111-1111-111111111131") } // Sapiens (popular book)
            };
        }
    }
}
