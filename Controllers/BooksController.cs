using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Bookstore.Models;
using Online_Bookstore.Services;

namespace Online_Bookstore.Controllers
{
    [Authorize]
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookIRepository _bookRepository;
        public BooksController(IBookIRepository bookRepository) {
            _bookRepository = bookRepository;
        
        }
        [HttpGet]
        [Route("/")]
        public IActionResult getBooks()
        {
            return Ok(_bookRepository.GetBooks());
        }

        [HttpPost]
        [Route("/")]
        public IActionResult postBooks(Book book)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            _bookRepository.CreateBook(book);
            return Ok();
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult getBooks(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPatch]
        [Route("/{id}")]
        public IActionResult UpdateBooks(int id)
        {
            var book = _bookRepository.GetBookById(id);
            
            if (book == null)
                return NotFound();
            
            _bookRepository.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        [Route("/{id}")] // id is served as input and it can be routed through it /id it will delete book with this id if it is found
        public IActionResult DeleteBooks(int id)
        {
            var result = _bookRepository.DeleteBook(id);
            
            if(result == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
