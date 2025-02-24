using Library_Management.API.Data;
using Library_Management.API.Mapping;
using Library_Management.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly LibDbContext _db;
        public BooksController(LibDbContext db) 
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(NewBookRequest request)
        {
            var book = request.ToModel();
            await _db.AddAsync(book);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id}, book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(book == null) 
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _db.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
