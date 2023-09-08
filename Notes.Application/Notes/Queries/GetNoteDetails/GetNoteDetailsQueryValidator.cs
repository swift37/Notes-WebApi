using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(updateNoteComm => updateNoteComm.Id)
                .NotEqual(Guid.Empty);
            RuleFor(updateNoteComm => updateNoteComm.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
