using Kitaplik.DataAccess.Abstract;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Context;
using Kitaplik.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.DataAccess.Concrete.EntityFrameworkCore
{
    public class BookDal : Repository<Book>,IBookDal
    {
        public BookDal(KitaplikContext context) : base(context)
        {

        }
    }
}
