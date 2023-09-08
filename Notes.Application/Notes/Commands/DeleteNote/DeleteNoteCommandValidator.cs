using FluentValidation;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteComm => deleteNoteComm.Id)
                .NotEqual(Guid.Empty);
            RuleFor(deleteNoteComm => deleteNoteComm.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
