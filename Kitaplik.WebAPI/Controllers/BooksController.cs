using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BookDto bookDto = await _bookService.GetBookByIdAsync(id);
            return bookDto is not null ? Ok(bookDto) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BookDto> bookDtos = await _bookService.GetAllAsync();
            return bookDtos is null ? BadRequest() : Ok(bookDtos);
        }

        [HttpDelete]
        
        public async Task<IActionResult> Delete(int id)
        {
            int response = await _bookService.DeleteBookAsync(id);
            return Ok(response);
        }

        [HttpPost]

        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            int response = await _bookService.AddBookAsync(bookDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookDto bookDto)
        {
            int response = await _bookService.UpdateBookAsync(bookDto);
            return response > 0 ? Ok("Güncelleme başarılı") : BadRequest("Bir problem oluştu");
        }

        




    }
}
