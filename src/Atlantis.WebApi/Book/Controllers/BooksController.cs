namespace Atlantis.WebApi.Book.Controllers
{
    using Atlantis.WebApi.Book.Business;
    using Atlantis.WebApi.Shared.Context.Accessors;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IUserContextAccessor _userContextAccessor;

        public BooksController(
            IBookService service,
            IUserContextAccessor userContextAccessor)
        {
            _service = service;
            _userContextAccessor = userContextAccessor;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Ping!!!");
        }

        [HttpGet("{id:guid}")]
        public IActionResult Read(Guid id)
        {
            var bookDto = _service.Read(id);
            return Ok(bookDto);
        }
    }
}
