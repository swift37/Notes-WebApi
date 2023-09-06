namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteListVM
    {
        public IList<NoteLookupDTO> Notes { get; set; } = new List<NoteLookupDTO>();
    }
}
