using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Title { get; set; }

        public string? Details { get; set; }
    }
}
