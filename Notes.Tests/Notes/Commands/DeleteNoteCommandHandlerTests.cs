using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            // Act
            await handler.Handle(
                new DeleteNoteCommand
                {
                    UserId = NotesContextFactory.UserOneId,
                    Id = NotesContextFactory.NoteIdForDelete
                },
                CancellationToken.None);

            // Assert
            Assert.Null(
                await Context.Notes.SingleOrDefaultAsync(note => 
                    note.Id == NotesContextFactory.NoteIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new DeleteNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = NotesContextFactory.UserOneId
                },
                CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteNoteCommandHandler(Context);
            var createHandler = new CreateNoteCommandHandler(Context);
            var noteId = await createHandler.Handle(
                new CreateNoteCommand
                {
                    Title = "Note Title",
                    UserId = NotesContextFactory.UserOneId
                },
                CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await deleteHandler.Handle(
                new DeleteNoteCommand
                {
                    Id = noteId,
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
        }
    }
}
