using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVM : IMapWith<Note>
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Details { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVM>()
                .ForMember(noteVM => noteVM.Id, 
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVM => noteVM.Title, 
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVM => noteVM.Details, 
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVM => noteVM.CreationDate, 
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVM => noteVM.EditDate, 
                    opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
