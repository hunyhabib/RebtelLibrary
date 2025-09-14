using Microsoft.Extensions.Logging;
using Rebtel.LibraryManagement.Application.Profiles;

namespace Rebtel.LibraryManagement.UnitTests.Application.Profiles
{
    public class ProfileTests
    {

        [Fact]
        public void Should_Map_Book_To_BookDTO_Correctly()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BooksProfile>();
            }, Mock.Of<LoggerFactory>());
            var mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Should_Map_User_To_UserDTO_Correctly()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UsersProfile>();
            }, Mock.Of<LoggerFactory>());
            var mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }



    }
}
