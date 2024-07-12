using Kitaplik.DataAccess.Concrete.EntityFrameworkCore;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Abstract
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<List<BookDto>> GetAllAsync();
        Task<List<BookDto>> GetAllByNameFilterAsync(string filter = "");
        Task<int> AddBookAsync(BookDto bookDto);
        Task<int> UpdateBookAsync(BookDto bookDto);
        Task<int> DeleteBookAsync(int id);
    }

}
