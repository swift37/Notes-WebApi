using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);
            var updatedTitle = "Updated Title";

            // Act
            await handler.Handle(
                new UpdateNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForUpdate,
                    UserId = NotesContextFactory.UserTwoId,
                    Title = updatedTitle
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Notes.SingleOrDefaultAsync(note => 
                    note.Id == NotesContextFactory.NoteIdForUpdate && note.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new UpdateNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = NotesContextFactory.UserOneId
                },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new UpdateNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForUpdate,
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
        }
    }
}
