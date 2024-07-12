using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.MVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly IBookService _bookService;
        private readonly INoteService _noteService;
        IShareSettingService _shareSettingService;

        public NoteController(IBookService bookService, INoteService noteService, IShareSettingService shareSettingService)
        {
            _bookService = bookService;
            _noteService = noteService;
            _shareSettingService = shareSettingService;
        }
        public async Task<IActionResult> Index()
        {
            List<NoteDto> notes = await _noteService.GetAllNotesAsync();

            return View(notes);
        }

        public async Task<IActionResult> Details(int id)
        {
            NoteDto noteDto = await _noteService.GetNoteByIdAsync(id);
            return View(noteDto);
        }

        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteDto noteDto)
        {
            int response = await _noteService.AddNoteAsync(noteDto);
            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateNote(int id)
        {
            BookDto bookDto = await _bookService.GetBookByIdAsync(id);
            return View(bookDto);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateNote(NoteDto noteDto)
        {
            int res = await _noteService.UpdateNoteAsync(noteDto);
            return res > 0 ? RedirectToAction("index") : View(noteDto);
        }
    }
}
