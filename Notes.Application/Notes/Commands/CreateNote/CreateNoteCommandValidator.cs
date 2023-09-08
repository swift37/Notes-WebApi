using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteComm => createNoteComm.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(createNoteComm => createNoteComm.Title)
                .NotEmpty()
                .MaximumLength(128);
        }
    }
}
