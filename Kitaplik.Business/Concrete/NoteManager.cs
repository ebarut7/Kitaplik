using Kitaplik.Business.Abstract;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NoteManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddNoteAsync(NoteDto noteDto)
        {
            Note note = await _unitOfWork.NoteDal.GetAsync(x => x.Id == noteDto.Id);
            note.Id = noteDto.Id;
            noteDto.DateUpdated = DateTime.Now;
            note.DateUpdated = noteDto.DateUpdated;
            note.DateCreated = note.DateCreated;
            note.BookId = noteDto.BookId;
            note.ShareSettingId = noteDto.ShareSettingId;
            

            await _unitOfWork.NoteDal.AddAsync(note);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteNoteAsync(int id)
        {
            Note note = await _unitOfWork.NoteDal.GetAsync(p => p.Id == id);
            await _unitOfWork.NoteDal.DeleteAsync(note);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<NoteDto>> GetAllNotesAsync()
        {
            List<Note> notes = await _unitOfWork.NoteDal.GetAllAsync();
            List<NoteDto> noteDtos = new List<NoteDto>();
            foreach (Note note in notes)
            {
                noteDtos.Add(new NoteDto()
                {
                    
                    Content = note.Content,
                    DateCreated = note.DateCreated,
                    DateUpdated = note.DateUpdated,
                    Id = note.Id,
                    IsShared = note.IsShared,
                    BookId = note.BookId,
                    ShareSettingId = note.ShareSettingId,
                  

                });
            }
            return noteDtos;
        }

        public async Task<NoteDto> GetNoteByIdAsync(int id)
        {
            Note note = await _unitOfWork.NoteDal.GetAsync(x => x.Id == id);
            return new NoteDto()
            {
               
                IsShared = note.IsShared,
                Content = note.Content,
                DateCreated = note.DateCreated,
                DateUpdated = note.DateUpdated,
                Id = note.Id,
                BookId= note.BookId,
                ShareSettingId= note.ShareSettingId,
            };
        }

        public async Task<int> UpdateNoteAsync(NoteDto noteDto)
        {
            Note note = await _unitOfWork.NoteDal.GetAsync(x => x.Id == noteDto.Id);
            note.IsShared = noteDto.IsShared;
            note.Content = noteDto.Content;
            note.DateCreated = noteDto.DateCreated;
            note.DateUpdated = noteDto.DateUpdated;
            note.Id = noteDto.Id;
            note.BookId = noteDto.BookId;
            note.ShareSettingId = noteDto.ShareSettingId;
            
            


            await _unitOfWork.NoteDal.UpdateAsync(note);

            return await _unitOfWork.SaveAsync();
        }
    }
}
