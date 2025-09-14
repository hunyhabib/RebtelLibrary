using FluentValidation;

namespace Rebtel.LibraryManagement.Application.Queries.Users.GetUserReadingPace;

internal class GetUserReadingPaceQueryValidation : AbstractValidator<GetUserReadingPaceQuery>
{
    public GetUserReadingPaceQueryValidation()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("BookId is required.");
    }
}
