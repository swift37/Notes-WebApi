using Microsoft.EntityFrameworkCore;
using Notes.DAL.Context;
using Notes.Domain;

namespace Notes.Tests.Common
{
    public static class NotesContextFactory
    {
        public static Guid UserOneId = Guid.NewGuid();
        public static Guid UserTwoId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();

            context.Notes.AddRange(
                new Note
                {
                    Id = Guid.Parse("801ED160-04DD-46D8-A036-6F5D52C85B81"),
                    UserId = UserOneId,
                    Title = "Title1",
                    Details = "Details1",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = Guid.Parse("385A094F-C910-401D-8A34-5F76B58DF59F"),
                    UserId = UserTwoId,
                    Title = "Title2",
                    Details = "Details2",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForDelete,
                    UserId = UserOneId,
                    Title = "Title3",
                    Details = "Details3",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForUpdate,
                    UserId = UserTwoId,
                    Title = "Title4",
                    Details = "Details4",
                    CreationDate = DateTime.Today,
                    EditDate = null
                }
            );
            context.SaveChanges();
            return context;
        }
        
        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
