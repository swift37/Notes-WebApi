using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVM>
    {
        public Guid UserId { get; set; }
    }
}
