using MediatR;
using Notes.Application.Common.Exeptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INotesDbContext _context;

        public DeleteNoteCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (note is null || note.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
