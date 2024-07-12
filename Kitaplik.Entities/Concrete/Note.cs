using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsShared { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int BookId { get; set; }
        public int ShareSettingId { get; set; }

        public Book Book { get; set; }

        public ShareSetting ShareSetting { get; set; }
    }

}
