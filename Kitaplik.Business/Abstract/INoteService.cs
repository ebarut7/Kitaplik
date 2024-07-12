using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Abstract
{
    public interface INoteService
    {
        Task<NoteDto> GetNoteByIdAsync(int id);
        Task<List<NoteDto>> GetAllNotesAsync();
        Task<int> AddNoteAsync(NoteDto noteDto);
        Task<int> UpdateNoteAsync(NoteDto noteDto);
        Task<int> DeleteNoteAsync(int id);
    }

}
