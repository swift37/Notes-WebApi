using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(updateNoteComm => updateNoteComm.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
