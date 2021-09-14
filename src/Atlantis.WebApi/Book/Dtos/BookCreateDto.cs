namespace Atlantis.WebApi.Book.Dtos
{
    public class BookCreateDto
    {
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
