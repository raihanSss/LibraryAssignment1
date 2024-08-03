using LibraryAssignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAssignment.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private static List<Book> _bookCollection = new List<Book>();

        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!_bookCollection.Any(b => b.Title == book.Title))
            {
                _bookCollection.Add(book);
                return Ok(new { message = "Buku berhasil ditambah" });
            }
            return BadRequest(new { message = "Buku sudah ada" });
        }

        [HttpDelete("remove/{title}")]
        public IActionResult RemoveBook(string title)
        {
            var book = _bookCollection.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                _bookCollection.Remove(book);
                return Ok(new { message = "Buku berhasil dihapus" });
            }
            return NotFound(new { message = "Buku tidka ada" });
        }

        [HttpGet("display")]
        public ActionResult<List<Book>> DisplayBooks()
        {
            return Ok(_bookCollection);
        }
    }
}
