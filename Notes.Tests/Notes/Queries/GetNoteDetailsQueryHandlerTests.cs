using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.DAL.Context;
using Notes.Tests.Common;
using Shouldly;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        public NotesDbContext Context;
        public IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture testFixture)
        {
            Context = testFixture.Context;
            Mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserTwoId,
                    Id = Guid.Parse("385A094F-C910-401D-8A34-5F76B58DF59F")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<NoteDetailsVM>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
