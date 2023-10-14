using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDTO : IMapWith<Note>
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Details { get; set; }

        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDTO>()
                .ForMember(noteDTO => noteDTO.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDTO => noteDTO.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDTO => noteDTO.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(noteDTO => noteDTO.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate));
        }
    }
}
