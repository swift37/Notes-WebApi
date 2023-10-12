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
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns NoteListVM</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteListVM>> GetAll()
        {
            var query = new GetNoteListQuery { UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/A769980B-005B-4977-8DE2-5D49B93507C3
        /// </remarks>
        /// <param name="id">Note id (Guid)</param>
        /// <returns>Returns NoteDetailsVM</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteDetailsVM>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery { Id = id, UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create a note
        /// </summary>
        /// <remarks>
        /// POST /note
        /// {
        ///     title: "note title",
        ///     details: "note details"
        /// }
        /// </remarks>
        /// <param name="createNoteDTO">CreateNoteDTO</param>
        /// <returns>Returns id (Guid)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDTO createNoteDTO)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDTO);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Update the note
        /// </summary>
        /// <remarks>
        /// PUT /note 
        /// {
        ///     title: "updated note title"
        /// }
        /// </remarks>
        /// <param name="updateNoteDTO">UpdateNoteDTO</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDTO updateNoteDTO)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDTO);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the note by id
        /// </summary>
        /// <remarks>
        /// DELETE /note/E3F013FE-DB29-4321-B8DF-83F6942B2432
        /// </remarks>
        /// <param name="id">Note id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand { Id = id, UserId = UserId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
