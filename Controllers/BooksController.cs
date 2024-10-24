using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Bookstore.Models;
using Online_Bookstore.Services.Interfaces;

namespace Online_Bookstore.Controllers
{
    [Authorize]
    [Route("api/books")]
    [ApiController]
    public class BooksController(IBookIRepository bookRepository) : ControllerBase
    {
        private readonly IBookIRepository _bookRepository = bookRepository;

        [HttpGet]
        [Route("")]
        public IActionResult GetBooks()
        {
            return Ok(_bookRepository.GetBooks());
        }

        [HttpPost]
        [Route("")]
        public IActionResult GetBooks(Book book)
        {
            
            if (!ModelState.IsValid) {
                //List<string> errors = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errors.Add(error.ErrorMessage);
                //    }

                //}
                //var errorMessages=string.Join("\n", errors);
                //return BadRequest(errorMessages);
                return BadRequest(ModelState);
            }
            _bookRepository.CreateBook(book);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]  // {between this in route are changeable} outside it constants
        public IActionResult GetBooks(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateBooks(int id)
        {
            var book = _bookRepository.GetBookById(id);
            
            if (book == null)
                return NotFound();
            
            _bookRepository.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")] // id is served as input and it can be routed through it /id it will delete book with this id if it is found
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
