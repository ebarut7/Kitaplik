using Kitaplik.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete.Dtos
{
    public class NoteDto : IDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsShared { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int BookId { get; set; }
        public int ShareSettingId { get; set; }
    }
}
