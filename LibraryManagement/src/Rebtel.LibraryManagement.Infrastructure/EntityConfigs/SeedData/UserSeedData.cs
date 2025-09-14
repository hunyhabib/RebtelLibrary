using Rebtel.LibraryManagement.Domain.Aggregates;

namespace Rebtel.LibraryManagement.Infrastructure.EntityConfigs.SeedData
{
    internal static class UserSeedData
    {
        public static List<User> Users =>
             new List<User>
            {
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222221"),
                    Name = "Emma Johnson",
                    Email = "emma.johnson@email.com",
                    PhoneNumber = "+1-555-0101",
                    MembershipDate = new DateTime(2020, 1, 15)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Michael Chen",
                    Email = "michael.chen@email.com",
                    PhoneNumber = "+1-555-0102",
                    MembershipDate = new DateTime(2019, 8, 23)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    Name = "Sarah Williams",
                    Email = "sarah.williams@email.com",
                    PhoneNumber = "+1-555-0103",
                    MembershipDate = new DateTime(2021, 3, 10)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222224"),
                    Name = "David Rodriguez",
                    Email = "david.rodriguez@email.com",
                    PhoneNumber = "+1-555-0104",
                    MembershipDate = new DateTime(2018, 11, 5)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    Name = "Lisa Anderson",
                    Email = "lisa.anderson@email.com",
                    PhoneNumber = "+1-555-0105",
                    MembershipDate = new DateTime(2020, 7, 18)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    Name = "James Wilson",
                    Email = "james.wilson@email.com",
                    PhoneNumber = "+1-555-0106",
                    MembershipDate = new DateTime(2019, 4, 12)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222227"),
                    Name = "Maria Garcia",
                    Email = "maria.garcia@email.com",
                    PhoneNumber = "+1-555-0107",
                    MembershipDate = new DateTime(2022, 1, 8)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222228"),
                    Name = "Robert Taylor",
                    Email = "robert.taylor@email.com",
                    PhoneNumber = "+1-555-0108",
                    MembershipDate = new DateTime(2017, 9, 25)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222229"),
                    Name = "Jennifer Brown",
                    Email = "jennifer.brown@email.com",
                    PhoneNumber = "+1-555-0109",
                    MembershipDate = new DateTime(2021, 6, 14)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                    Name = "Christopher Davis",
                    Email = "christopher.davis@email.com",
                    PhoneNumber = "+1-555-0110",
                    MembershipDate = new DateTime(2020, 12, 3)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222231"),
                    Name = "Amanda Miller",
                    Email = "amanda.miller@email.com",
                    PhoneNumber = "+1-555-0111",
                    MembershipDate = new DateTime(2018, 5, 20)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222232"),
                    Name = "Daniel Lee",
                    Email = "daniel.lee@email.com",
                    PhoneNumber = "+1-555-0112",
                    MembershipDate = new DateTime(2019, 10, 7)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222233"),
                    Name = "Ashley Martinez",
                    Email = "ashley.martinez@email.com",
                    PhoneNumber = "+1-555-0113",
                    MembershipDate = new DateTime(2021, 2, 28)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222234"),
                    Name = "Matthew White",
                    Email = "matthew.white@email.com",
                    PhoneNumber = "+1-555-0114",
                    MembershipDate = new DateTime(2022, 8, 16)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222235"),
                    Name = "Jessica Thompson",
                    Email = "jessica.thompson@email.com",
                    PhoneNumber = "+1-555-0115",
                    MembershipDate = new DateTime(2017, 12, 11)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222236"),
                    Name = "Andrew Jackson",
                    Email = "andrew.jackson@email.com",
                    PhoneNumber = "+1-555-0116",
                    MembershipDate = new DateTime(2020, 4, 22)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222237"),
                    Name = "Nicole Harris",
                    Email = "nicole.harris@email.com",
                    PhoneNumber = "+1-555-0117",
                    MembershipDate = new DateTime(2019, 1, 30)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222238"),
                    Name = "Joshua Clark",
                    Email = "joshua.clark@email.com",
                    PhoneNumber = "+1-555-0118",
                    MembershipDate = new DateTime(2021, 9, 5)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222239"),
                    Name = "Stephanie Lewis",
                    Email = "stephanie.lewis@email.com",
                    PhoneNumber = "+1-555-0119",
                    MembershipDate = new DateTime(2018, 7, 13)
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222240"),
                    Name = "Ryan Walker",
                    Email = "ryan.walker@email.com",
                    PhoneNumber = "+1-555-0120",
                    MembershipDate = new DateTime(2022, 3, 9)
                }
            };
    }
}