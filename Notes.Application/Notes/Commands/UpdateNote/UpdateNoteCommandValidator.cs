using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteComm => updateNoteComm.Id)
                .NotEqual(Guid.Empty);
            RuleFor(updateNoteComm => updateNoteComm.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(updateNoteComm => updateNoteComm.Title)
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
