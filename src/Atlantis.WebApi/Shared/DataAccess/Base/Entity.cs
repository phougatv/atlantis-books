namespace Atlantis.WebApi.Shared.DataAccess.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class Entity<TId>
    {
        /// <summary>
        /// The id
        /// </summary>
        [Key]
        public TId Id { get; set; }

        /// <summary>
        /// The created on.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// The updated on.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}
