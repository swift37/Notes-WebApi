using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.DAL.Context;
using Notes.Tests.Common;
using Shouldly;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        public NotesDbContext Context;
        public IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture testFixture)
        {
            Context = testFixture.Context;
            Mapper = testFixture.Mapper;
        }

        [Fact]
        public async void GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetNoteListQuery
                {
                    UserId = NotesContextFactory.UserTwoId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<NoteListVM>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}
