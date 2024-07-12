using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Abstract
{
    public interface IShareSettingService
    {
        Task<ShareSettingDto> GetShareSettingByIdAsync(int id);
        Task<List<ShareSettingDto>> GetAllShareSettingsAsync();
        Task<int> AddShareSettingAsync(ShareSettingDto shareSettingDto);
        Task<int> UpdateShareSettingAsync(ShareSettingDto shareSettingDto);
        Task<int> DeleteShareSettingAsync(int id);
    }

}
