using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVM>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper) 
            => (_context, _mapper) = (context, mapper); 

        public async Task<NoteDetailsVM> Handle(
            GetNoteDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (note is null || note.UserId != request.UserId)
                throw new NotFoundException(nameof(note), request.Id);

            return _mapper.Map<NoteDetailsVM>(note);
        }
    }
}
