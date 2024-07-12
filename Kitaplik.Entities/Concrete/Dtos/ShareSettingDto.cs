using Kitaplik.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete.Dtos
{
    public class ShareSettingDto : IDto
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFriendsOnly { get; set; }

        public int NoteId { get; set; }
    }
}
