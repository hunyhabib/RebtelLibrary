using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rebtel.LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CopiesAvailable = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowRecord",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowRecord", x => new { x.BookId, x.BorrowRecordId });
                    table.ForeignKey(
                        name: "FK_BookBorrowRecord_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowRecord_BorrowRecords_BorrowRecordId",
                        column: x => x.BorrowRecordId,
                        principalTable: "BorrowRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CopiesAvailable", "ISBN", "PageCount", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Harper Lee", 5, "978-0-06-112008-4", 324, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "George Orwell", 3, "978-0-452-28423-4", 328, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Jane Austen", 4, "978-0-14-143951-8", 432, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "F. Scott Fitzgerald", 6, "978-0-7432-7356-5", 180, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), "J.D. Salinger", 2, "978-0-316-76948-0", 277, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), "Frank Herbert", 4, "978-0-441-17271-9", 688, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), "Isaac Asimov", 3, "978-0-553-29335-6", 244, new DateTime(1951, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundation" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), "Douglas Adams", 5, "978-0-345-39180-3", 224, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), "William Gibson", 2, "978-0-441-56956-9", 271, new DateTime(1984, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neuromancer" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), "Orson Scott Card", 4, "978-0-812-55070-2", 324, new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ender's Game" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), "J.R.R. Tolkien", 6, "978-0-547-92822-7", 366, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), "J.R.R. Tolkien", 3, "978-0-547-92821-0", 479, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Fellowship of the Ring" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), "J.K. Rowling", 8, "978-0-7475-3269-9", 223, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), "George R.R. Martin", 5, "978-0-553-10354-0", 694, new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), "Patrick Rothfuss", 3, "978-0-7564-0474-1", 662, new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Name of the Wind" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), "Stieg Larsson", 4, "978-0-307-45454-1", 590, new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Girl with the Dragon Tattoo" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), "Gillian Flynn", 3, "978-0-307-58836-4", 419, new DateTime(2012, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gone Girl" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), "Dan Brown", 5, "978-0-307-47492-1", 489, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Da Vinci Code" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), "Agatha Christie", 4, "978-0-06-207348-6", 264, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "And Then There Were None" },
                    { new Guid("11111111-1111-1111-1111-111111111130"), "Raymond Chandler", 2, "978-0-394-75828-5", 231, new DateTime(1939, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Big Sleep" },
                    { new Guid("11111111-1111-1111-1111-111111111131"), "Yuval Noah Harari", 6, "978-0-062-31609-6", 443, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapiens: A Brief History of Humankind" },
                    { new Guid("11111111-1111-1111-1111-111111111132"), "Tara Westover", 7, "978-0-399-59050-4", 334, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educated" },
                    { new Guid("11111111-1111-1111-1111-111111111133"), "Rebecca Skloot", 3, "978-1-400-05217-2", 381, new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Immortal Life of Henrietta Lacks" },
                    { new Guid("11111111-1111-1111-1111-111111111134"), "Daniel Kahneman", 4, "978-0-374-53355-7", 499, new DateTime(2011, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thinking, Fast and Slow" },
                    { new Guid("11111111-1111-1111-1111-111111111135"), "Charles Duhigg", 5, "978-1-400-06928-6", 371, new DateTime(2012, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Power of Habit" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "MembershipDate", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), "emma.johnson@email.com", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma Johnson", "+1-555-0101" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "michael.chen@email.com", new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Chen", "+1-555-0102" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), "sarah.williams@email.com", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah Williams", "+1-555-0103" },
                    { new Guid("22222222-2222-2222-2222-222222222224"), "david.rodriguez@email.com", new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Rodriguez", "+1-555-0104" },
                    { new Guid("22222222-2222-2222-2222-222222222225"), "lisa.anderson@email.com", new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa Anderson", "+1-555-0105" },
                    { new Guid("22222222-2222-2222-2222-222222222226"), "james.wilson@email.com", new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Wilson", "+1-555-0106" },
                    { new Guid("22222222-2222-2222-2222-222222222227"), "maria.garcia@email.com", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Garcia", "+1-555-0107" },
                    { new Guid("22222222-2222-2222-2222-222222222228"), "robert.taylor@email.com", new DateTime(2017, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Taylor", "+1-555-0108" },
                    { new Guid("22222222-2222-2222-2222-222222222229"), "jennifer.brown@email.com", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer Brown", "+1-555-0109" },
                    { new Guid("22222222-2222-2222-2222-222222222230"), "christopher.davis@email.com", new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Davis", "+1-555-0110" },
                    { new Guid("22222222-2222-2222-2222-222222222231"), "amanda.miller@email.com", new DateTime(2018, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amanda Miller", "+1-555-0111" },
                    { new Guid("22222222-2222-2222-2222-222222222232"), "daniel.lee@email.com", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Lee", "+1-555-0112" },
                    { new Guid("22222222-2222-2222-2222-222222222233"), "ashley.martinez@email.com", new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ashley Martinez", "+1-555-0113" },
                    { new Guid("22222222-2222-2222-2222-222222222234"), "matthew.white@email.com", new DateTime(2022, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew White", "+1-555-0114" },
                    { new Guid("22222222-2222-2222-2222-222222222235"), "jessica.thompson@email.com", new DateTime(2017, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jessica Thompson", "+1-555-0115" },
                    { new Guid("22222222-2222-2222-2222-222222222236"), "andrew.jackson@email.com", new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew Jackson", "+1-555-0116" },
                    { new Guid("22222222-2222-2222-2222-222222222237"), "nicole.harris@email.com", new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicole Harris", "+1-555-0117" },
                    { new Guid("22222222-2222-2222-2222-222222222238"), "joshua.clark@email.com", new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshua Clark", "+1-555-0118" },
                    { new Guid("22222222-2222-2222-2222-222222222239"), "stephanie.lewis@email.com", new DateTime(2018, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephanie Lewis", "+1-555-0119" },
                    { new Guid("22222222-2222-2222-2222-222222222240"), "ryan.walker@email.com", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryan Walker", "+1-555-0120" }
                });

            migrationBuilder.InsertData(
                table: "BorrowRecords",
                columns: new[] { "Id", "BorrowDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-000000000001"), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222221") },
                    { new Guid("33333333-3333-3333-3333-000000000002"), new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("33333333-3333-3333-3333-000000000003"), new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222223") },
                    { new Guid("33333333-3333-3333-3333-000000000004"), new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222224") },
                    { new Guid("33333333-3333-3333-3333-000000000005"), new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222225") },
                    { new Guid("33333333-3333-3333-3333-000000000006"), new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222226") },
                    { new Guid("33333333-3333-3333-3333-000000000007"), new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222227") },
                    { new Guid("33333333-3333-3333-3333-000000000008"), new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222228") },
                    { new Guid("33333333-3333-3333-3333-000000000009"), new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222229") },
                    { new Guid("33333333-3333-3333-3333-000000000010"), new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222230") },
                    { new Guid("33333333-3333-3333-3333-000000000011"), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222231") },
                    { new Guid("33333333-3333-3333-3333-000000000012"), new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222232") },
                    { new Guid("33333333-3333-3333-3333-000000000013"), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222233") },
                    { new Guid("33333333-3333-3333-3333-000000000014"), new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222234") },
                    { new Guid("33333333-3333-3333-3333-000000000015"), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222235") },
                    { new Guid("33333333-3333-3333-3333-000000000016"), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222236") },
                    { new Guid("33333333-3333-3333-3333-000000000017"), new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222237") },
                    { new Guid("33333333-3333-3333-3333-000000000018"), new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222238") },
                    { new Guid("33333333-3333-3333-3333-000000000019"), new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222239") },
                    { new Guid("33333333-3333-3333-3333-000000000020"), new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222240") },
                    { new Guid("33333333-3333-3333-3333-000000000021"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222221") },
                    { new Guid("33333333-3333-3333-3333-000000000022"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("33333333-3333-3333-3333-000000000023"), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222223") },
                    { new Guid("33333333-3333-3333-3333-000000000024"), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222224") },
                    { new Guid("33333333-3333-3333-3333-000000000025"), new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222225") },
                    { new Guid("33333333-3333-3333-3333-000000000026"), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222226") },
                    { new Guid("33333333-3333-3333-3333-000000000027"), new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222227") },
                    { new Guid("33333333-3333-3333-3333-000000000028"), new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222228") },
                    { new Guid("33333333-3333-3333-3333-000000000029"), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222229") },
                    { new Guid("33333333-3333-3333-3333-000000000030"), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222230") },
                    { new Guid("33333333-3333-3333-3333-000000000031"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22222222-2222-2222-2222-222222222231") },
                    { new Guid("33333333-3333-3333-3333-000000000032"), new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22222222-2222-2222-2222-222222222232") },
                    { new Guid("33333333-3333-3333-3333-000000000033"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22222222-2222-2222-2222-222222222233") },
                    { new Guid("33333333-3333-3333-3333-000000000034"), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22222222-2222-2222-2222-222222222234") },
                    { new Guid("33333333-3333-3333-3333-000000000035"), new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("22222222-2222-2222-2222-222222222235") }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowRecord",
                columns: new[] { "BookId", "BorrowRecordId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-000000000003") },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("33333333-3333-3333-3333-000000000003") },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("33333333-3333-3333-3333-000000000016") },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("33333333-3333-3333-3333-000000000029") },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("33333333-3333-3333-3333-000000000028") },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("33333333-3333-3333-3333-000000000030") },
                    { new Guid("11111111-1111-1111-1111-111111111115"), new Guid("33333333-3333-3333-3333-000000000008") },
                    { new Guid("11111111-1111-1111-1111-111111111116"), new Guid("33333333-3333-3333-3333-000000000033") },
                    { new Guid("11111111-1111-1111-1111-111111111117"), new Guid("33333333-3333-3333-3333-000000000012") },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("33333333-3333-3333-3333-000000000004") },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("33333333-3333-3333-3333-000000000013") },
                    { new Guid("11111111-1111-1111-1111-111111111118"), new Guid("33333333-3333-3333-3333-000000000027") },
                    { new Guid("11111111-1111-1111-1111-111111111119"), new Guid("33333333-3333-3333-3333-000000000010") },
                    { new Guid("11111111-1111-1111-1111-111111111120"), new Guid("33333333-3333-3333-3333-000000000013") },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("33333333-3333-3333-3333-000000000005") },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("33333333-3333-3333-3333-000000000014") },
                    { new Guid("11111111-1111-1111-1111-111111111121"), new Guid("33333333-3333-3333-3333-000000000026") },
                    { new Guid("11111111-1111-1111-1111-111111111122"), new Guid("33333333-3333-3333-3333-000000000026") },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("33333333-3333-3333-3333-000000000001") },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("33333333-3333-3333-3333-000000000009") },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("33333333-3333-3333-3333-000000000022") },
                    { new Guid("11111111-1111-1111-1111-111111111123"), new Guid("33333333-3333-3333-3333-000000000034") },
                    { new Guid("11111111-1111-1111-1111-111111111124"), new Guid("33333333-3333-3333-3333-000000000015") },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("33333333-3333-3333-3333-000000000007") },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("33333333-3333-3333-3333-000000000020") },
                    { new Guid("11111111-1111-1111-1111-111111111126"), new Guid("33333333-3333-3333-3333-000000000032") },
                    { new Guid("11111111-1111-1111-1111-111111111127"), new Guid("33333333-3333-3333-3333-000000000034") },
                    { new Guid("11111111-1111-1111-1111-111111111128"), new Guid("33333333-3333-3333-3333-000000000017") },
                    { new Guid("11111111-1111-1111-1111-111111111129"), new Guid("33333333-3333-3333-3333-000000000019") },
                    { new Guid("11111111-1111-1111-1111-111111111131"), new Guid("33333333-3333-3333-3333-000000000002") },
                    { new Guid("11111111-1111-1111-1111-111111111131"), new Guid("33333333-3333-3333-3333-000000000011") },
                    { new Guid("11111111-1111-1111-1111-111111111131"), new Guid("33333333-3333-3333-3333-000000000024") },
                    { new Guid("11111111-1111-1111-1111-111111111131"), new Guid("33333333-3333-3333-3333-000000000035") },
                    { new Guid("11111111-1111-1111-1111-111111111132"), new Guid("33333333-3333-3333-3333-000000000006") },
                    { new Guid("11111111-1111-1111-1111-111111111132"), new Guid("33333333-3333-3333-3333-000000000018") },
                    { new Guid("11111111-1111-1111-1111-111111111132"), new Guid("33333333-3333-3333-3333-000000000031") },
                    { new Guid("11111111-1111-1111-1111-111111111133"), new Guid("33333333-3333-3333-3333-000000000021") },
                    { new Guid("11111111-1111-1111-1111-111111111134"), new Guid("33333333-3333-3333-3333-000000000023") },
                    { new Guid("11111111-1111-1111-1111-111111111135"), new Guid("33333333-3333-3333-3333-000000000025") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowRecord_BorrowRecordId",
                table: "BookBorrowRecord",
                column: "BorrowRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishedDate",
                table: "Books",
                column: "PublishedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_UserId",
                table: "BorrowRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MembershipDate",
                table: "Users",
                column: "MembershipDate");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowRecord");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
