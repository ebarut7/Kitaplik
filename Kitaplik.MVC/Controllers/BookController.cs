using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly INoteService _noteService;
        IShareSettingService _shareSettingService;

        public BookController(IBookService bookService, INoteService noteService, IShareSettingService shareSettingService)
        {
            _bookService = bookService;
            _noteService = noteService;
            _shareSettingService = shareSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BookDto> books = await _bookService.GetAllAsync();

           
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string filter)
        {
            List<BookDto> books=await _bookService.GetAllByNameFilterAsync(filter);
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            BookDto bookDto = await _bookService.GetBookByIdAsync(id);
            return View(bookDto);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            int response= await _bookService.AddBookAsync(bookDto);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            BookDto bookDto = await _bookService.GetBookByIdAsync(id);
           return View(bookDto);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDto bookDto)
        {
            int res = await _bookService.UpdateBookAsync(bookDto);
            return res > 0 ? RedirectToAction("index") : View(bookDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            int response= await _bookService.DeleteBookAsync(id);
            return response > 0 ? RedirectToAction("index") : RedirectToAction("details",new {id = id});
        }

    }
}
