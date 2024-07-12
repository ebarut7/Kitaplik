using Kitaplik.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Abstract
{
    public interface IUnitOfWork
    {
        IBookDal BookDal { get; }
        INoteDal NoteDal { get; }
        IUserDal UserDal { get; }
        IShareSettingDal ShareSettingDal { get; }
        Task<int> SaveAsync();
    }
}
