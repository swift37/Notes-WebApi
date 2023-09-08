using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDTO : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDTO, UpdateNoteCommand>()
                .ForMember(noteComm => noteComm.Id,
                    opt => opt.MapFrom(noteDTO => noteDTO.Id))
                .ForMember(noteComm => noteComm.Title,
                    opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteComm => noteComm.Details,
                    opt => opt.MapFrom(noteDTO => noteDTO.Details));
        }
    }
}
