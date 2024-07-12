using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            NoteDto noteDto = await _noteService.GetNoteByIdAsync(id);
            return noteDto is not null ? Ok(noteDto) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<NoteDto> noteDtos= await _noteService.GetAllNotesAsync();
            return noteDtos is not null ? Ok(noteDtos) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteDto noteDto)
        {
            int response= await _noteService.AddNoteAsync(noteDto);
            return response > 0 ? Ok("Başarılı şekilde eklendi") : NotFound("Bir hata alındı.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(NoteDto noteDto)
        {
            int response = await _noteService.UpdateNoteAsync(noteDto);
            return response > 0 ? Ok("Başarılı şekilde güncellendi") : NotFound("Bir hata alındı.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int response = await _noteService.DeleteNoteAsync(id);
            return response > 0 ? Ok("Veri silindi") : NotFound("Bir problem oluştu");
        }

    }
}
