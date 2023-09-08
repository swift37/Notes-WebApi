using Notes.DAL.Context;

namespace Notes.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
