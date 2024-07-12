using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete
{
    public class ShareSetting
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFriendsOnly { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }

}
