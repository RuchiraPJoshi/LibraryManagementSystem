using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Services.Interfaces;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly ILibraryService _libraryService;

        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetBooks() => Ok(_libraryService.GetBooks());

        [HttpGet("GetBook/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _libraryService.GetBook(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN
            };
            _libraryService.AddBook(book);
            return Ok(book);
        }

        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            var updated = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN
            };
            _libraryService.UpdateBook(id, updated);
            return Ok("Book Updated");
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _libraryService.DeleteBook(id);
            return Ok("Book Deleted");
        }
    }
}
