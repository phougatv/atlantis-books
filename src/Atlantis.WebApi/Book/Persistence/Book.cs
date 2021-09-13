namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base;
    using System;

    public class Book : Entity<Guid>
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int Year { get; set; }
    }
}
