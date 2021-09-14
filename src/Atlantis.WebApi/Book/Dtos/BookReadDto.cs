namespace Atlantis.WebApi.Book.Dtos
{
    using System;

    public class BookReadDto
    {
        /// <summary>
        /// Id, the primary key in the Book table.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The isbn - International Standard Book Number.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// The release year of the book
        /// </summary>
        public int Year { get; set; }
    }
}
