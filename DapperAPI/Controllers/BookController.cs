using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILibraryRepo _libraryRepo;
        private readonly IPeopleRepo _peopleRepo;
        public BookController(ILibraryRepo libraryRepo, IPeopleRepo peopleRepo)
        {
            _libraryRepo = libraryRepo;
            _peopleRepo = peopleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _libraryRepo.GetBookById(id);
                if (book == null)
                {
                    return NotFound(new { Message = "No se encontró el libro" });
                }
                else
                {
                    book.Author = await _peopleRepo.GetAuthorById(book.AuthorId);
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {Message = ex.Message});
            }


        }
    }
}
