using BookstoreApi.DBContexts;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found.");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddHero(Book hero)
        {
            _context.Books.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
        {
            var dbBook = await _context.Books.FindAsync(request.Id);
            if (dbBook == null)
                return BadRequest("Book not found.");

            dbBook.Title = request.Title;
            dbBook.Authors = request.Authors;
            dbBook.ReleaseDate = request.ReleaseDate;
            dbBook.Publisher = request.Publisher;
            dbBook.ISBN = request.ISBN;
            dbBook.ImgUrl = request.ImgUrl;
            dbBook.Price = request.Price;
            dbBook.Category = request.Category;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> Delete(int id)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook == null)
                return BadRequest("Book not found.");

            _context.Books.Remove(dbBook);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

    }
}
