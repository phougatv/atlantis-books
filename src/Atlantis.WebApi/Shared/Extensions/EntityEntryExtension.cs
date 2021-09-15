namespace Atlantis.WebApi.Shared.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;

    public static class EntityEntryExtension
    {
        internal static bool IsAdded(this EntityEntry entityEntry)
        {
            ThrowArgumentNullExceptionIfEntityEntryIsNull(entityEntry, nameof(entityEntry));
            return entityEntry.State == EntityState.Added;
        }

        internal static bool IsModified(this EntityEntry entityEntry)
        {
            ThrowArgumentNullExceptionIfEntityEntryIsNull(entityEntry, nameof(entityEntry));
            return entityEntry.State == EntityState.Modified;
        }

        internal static bool IsDeleted(this EntityEntry entityEntry)
        {
            ThrowArgumentNullExceptionIfEntityEntryIsNull(entityEntry, nameof(entityEntry));
            return entityEntry.State == EntityState.Deleted;
        }

        internal static void Detach(this EntityEntry entityEntry)
        {
            ThrowArgumentNullExceptionIfEntityEntryIsNull(entityEntry, nameof(entityEntry));
            entityEntry.State = EntityState.Detached;
        }

        internal static void Modify(this EntityEntry entityEntry)
        {
            ThrowArgumentNullExceptionIfEntityEntryIsNull(entityEntry, nameof(entityEntry));
            entityEntry.State = EntityState.Modified;
        }

        #region Private Methods
        private static void ThrowArgumentNullExceptionIfEntityEntryIsNull(this EntityEntry entityEntry, string nameOfArgument)
        {
            if (entityEntry == null)
                throw new ArgumentNullException(nameOfArgument);
        }
        #endregion Private Methods
    }
}
