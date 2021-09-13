namespace Atlantis.WebApi.Book.Business
{
    using System;

    public class BookDomainModel
    {
        /// <summary>
        /// The Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The isbn - International Standard Book Number.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// The release year of the book.
        /// </summary>
        public int Year { get; set; }
    }
}
