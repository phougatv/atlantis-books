namespace Atlantis.WebApi.Book.Persistence
{
    using Microsoft.EntityFrameworkCore;

    public class AtlantisDbContext : DbContext
    {
        public AtlantisDbContext(DbContextOptions<AtlantisDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        /// <summary>
        /// Removes pluralizing table name convention.
        /// </summary>
        /// <param name="modelBuilder">The model builder <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in entityTypes)
            {
                // Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational).
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(modelBuilder);
        }

        internal DbSet<Book> Books { get; set; }
    }
}
