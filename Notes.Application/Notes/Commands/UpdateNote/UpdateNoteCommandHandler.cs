using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exeptions;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INotesDbContext _context;

        public UpdateNoteCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (note is null || note.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);

            note.Title = request.Title;
            note.Details = request.Details;
            note.EditDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
