using Kitaplik.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete.Dtos
{
    public class BookDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ShelfLocation { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime DateAdded { get; set; }

        public int NoteId { get; set; }
        public int UserId { get; set; }
    }
}
