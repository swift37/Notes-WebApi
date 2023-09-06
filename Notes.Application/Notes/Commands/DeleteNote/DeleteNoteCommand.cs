using MediatR;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
