using Kitaplik.Business.Abstract;
using Kitaplik.DataAccess.Abstract;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserDal UserDal { get; }
        public IBookDal BookDal { get; }
        public INoteDal NoteDal { get; }
        public IShareSettingDal ShareSettingDal { get; }

        KitaplikContext _context;

        public UnitOfWork(IUserDal userDal, IBookDal bookDal, INoteDal noteDal, IShareSettingDal shareSettingDal, KitaplikContext context)
        {
            UserDal = userDal;
            BookDal = bookDal;
            NoteDal = noteDal;
            ShareSettingDal = shareSettingDal;
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync().Result;
        }
    }
}
