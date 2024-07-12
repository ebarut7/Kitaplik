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
    public class ShareSettingDal : Repository<ShareSetting>,IShareSettingDal
    {
        public ShareSettingDal(KitaplikContext context) : base(context)
        {

        }
    }
}
