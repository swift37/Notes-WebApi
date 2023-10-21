using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVM>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INotesDbContext context, IMapper mapper)
            => (_context, _mapper) = (context, mapper);

        public async Task<NoteListVM> Handle(
            GetNoteListQuery request, 
            CancellationToken cancellationToken)
        {
            var notesQuery = await _context.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDTO>(_mapper.ConfigurationProvider)
                .OrderByDescending(note => note.CreationDate)
                .ToListAsync(cancellationToken);

            return new NoteListVM { Notes = notesQuery };
        }
    }
}
