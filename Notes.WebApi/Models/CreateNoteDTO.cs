using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebApi.Models
{
    public class CreateNoteDTO : IMapWith<CreateNoteCommand>
    {
        public string? Title { get; set; }

        public string? Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDTO, CreateNoteCommand>()
                .ForMember(noteComm => noteComm.Title,
                    opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteComm => noteComm.Details,
                    opt => opt.MapFrom(noteDTO => noteDTO.Details));
        }
    }
}
