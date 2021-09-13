namespace Atlantis.WebApi.Book.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int Year { get; set; }
    }
}
