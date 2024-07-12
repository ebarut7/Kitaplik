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
    public class NoteDal : Repository<Note>, INoteDal
    {
        public NoteDal(KitaplikContext context) : base(context)
        {

        }
    }
}
