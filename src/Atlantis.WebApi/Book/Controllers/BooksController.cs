namespace Atlantis.WebApi.Book.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Ping!!!");
        }
    }
}
