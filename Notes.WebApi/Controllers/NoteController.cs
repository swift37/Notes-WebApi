using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Controllers.Base;
using Notes.WebApi.Models;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<NoteListVM>> GetAll()
        {
            var query = new GetNoteListQuery { UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<NoteDetailsVM>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery { Id = id, UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDTO createNoteDTO)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDTO);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Upate([FromBody] UpdateNoteDTO updateNoteDTO)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDTO);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand { Id = id, UserId = UserId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
