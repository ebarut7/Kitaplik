using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddBookAsync(BookDto bookDto)
        {
            Book book = await _unitOfWork.BookDal.GetAsync(x => x.Id == bookDto.Id);
            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.PublishedDate = bookDto.PublishedDate;
            book.ImageUrl = bookDto.ImageUrl;
            book.Id = bookDto.Id;
            book.Description = bookDto.Description;
            book.DateAdded = bookDto.PublishedDate;
            book.ShelfLocation = bookDto.ShelfLocation;
            book.NoteId = bookDto.NoteId;
            


            await _unitOfWork.BookDal.AddAsync(book);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            Book book = await _unitOfWork.BookDal.GetAsync(p => p.Id == id);
            await _unitOfWork.BookDal.DeleteAsync(book);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            List<Book> books = await _unitOfWork.BookDal.GetAllAsync();
            List<BookDto> bookDtos = new List<BookDto>();
            foreach (Book book in books)
            {
                bookDtos.Add(new BookDto()
                {
                    Title = book.Title,
                    Author = book.Author,
                    DateAdded = book.DateAdded,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate,
                    ShelfLocation = book.ShelfLocation,
                    Id = book.Id,
                    NoteId = book.NoteId,
                });
            }
            return bookDtos;
        }

        public async Task<List<BookDto>> GetAllByNameFilterAsync(string filter = "")
        {
            List<Book> products = await _unitOfWork.BookDal.GetAllAsync(x => x.Title.Contains(filter));
            List<BookDto> bookDtos = new List<BookDto>();
            foreach (Book book in products)
            {
                bookDtos.Add(new BookDto()
                {
                    Title = book.Title,
                    Author = book.Author,
                    DateAdded = book.DateAdded,
                    Description = book.Description,
                    Id = book.Id,
                    ImageUrl = book.ImageUrl,
                    PublishedDate = book.PublishedDate,
                    ShelfLocation = book.ShelfLocation,
                    ISBN = book.ISBN,
                    NoteId= book.NoteId,

                });
            }
            return bookDtos;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {

            Book book = await _unitOfWork.BookDal.GetAsync(x => x.Id == id);
            return new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                ShelfLocation = book.ShelfLocation,
                PublishedDate = book.PublishedDate,
                ImageUrl = book.ImageUrl,
                Id = book.Id,
                Description = book.Description,
                DateAdded = book.PublishedDate,
                NoteId = book.NoteId,
            };
        }

        public async Task<int> UpdateBookAsync(BookDto bookDto)
        {
            Book book = await _unitOfWork.BookDal.GetAsync(x => x.Id == bookDto.Id);
            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.PublishedDate = bookDto.PublishedDate;
            book.ImageUrl = bookDto.ImageUrl;
            book.Id = bookDto.Id;
            book.Description = bookDto.Description;
            book.DateAdded = bookDto.PublishedDate;
            book.ShelfLocation = bookDto.ShelfLocation;
            book.NoteId = bookDto.NoteId;


            await _unitOfWork.BookDal.UpdateAsync(book);

            return await _unitOfWork.SaveAsync();
        }
    }

}
