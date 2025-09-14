using Rebtel.LibraryManagement.UnitTests.Helpers;
using Moq.EntityFrameworkCore;

namespace Rebtel.LibraryManagement.UnitTests.Fixtures;

public class LibraryManagementDBFixture
{
    internal LibraryManagementContext Context { get; }

    public LibraryManagementDBFixture()
    {
        // Create mock context and DbSets
        var MockContext = new Mock<LibraryManagementContext>();
        MockContext.Setup(c => c.Books).ReturnsDbSet(TestDataHelper.GetSampleBooks());
        MockContext.Setup(c => c.Users).ReturnsDbSet(TestDataHelper.GetSampleUsers());
        MockContext.Setup(c => c.BorrowRecords).ReturnsDbSet(TestDataHelper.GetSampleBorrowRecords());
        Context = MockContext.Object;
    }
}
