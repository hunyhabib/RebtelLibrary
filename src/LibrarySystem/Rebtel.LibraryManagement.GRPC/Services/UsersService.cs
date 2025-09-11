namespace Rebtel.LibraryManagement.GRPC.Services
{
    public class UsersService : GRPC.UsersService.UsersServiceBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        //public override Task<GetMostBorrowingUsersResponse> GetMostBorrowingUsers(GetMostBorrowingUsers Request request, ServerCallContext context)
        //{
        //    return Task.FromResult(new HelloReply
        //    {
        //        Message = "Hello " + request.Name
        //    });
        //}
    }
}
