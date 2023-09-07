using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.DAL.EntityTypeConfigurations;
using Notes.Domain;

namespace Notes.DAL.Context
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
