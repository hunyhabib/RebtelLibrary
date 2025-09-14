using FluentValidation;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetMostBorrowingUser;

internal class GetMostBorrowingUserQueryValidation : AbstractValidator<GetMostBorrowingUserQuery>
{
    public GetMostBorrowingUserQueryValidation()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("StartDate is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("EndDate is required.");

        RuleFor(x => x.StartDate).LessThan(x => x.EndDate)
            .WithMessage("StartDate must be earlier than EndDate.");

        RuleFor(x=> x.Count).GreaterThan(0);
    }
}
