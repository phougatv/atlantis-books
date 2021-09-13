namespace Atlantis.WebApi.Book.Controllers
{
    using Atlantis.WebApi.Book.Business;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
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
