using Kitaplik.Business.Abstract;
using Kitaplik.DataAccess.Concrete.EntityFrameworkCore;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Concrete
{
    public class ShareSettingManager : IShareSettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShareSettingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddShareSettingAsync(ShareSettingDto shareSettingDto)
        {
            ShareSetting shareSetting = await _unitOfWork.ShareSettingDal.GetAsync(x => x.Id == shareSettingDto.Id);
            shareSetting.Id = shareSettingDto.Id;
            shareSetting.IsFriendsOnly = shareSettingDto.IsFriendsOnly;
            shareSetting.IsPublic = shareSettingDto.IsPublic;
            shareSetting.NoteId = shareSettingDto.NoteId;


            await _unitOfWork.ShareSettingDal.AddAsync(shareSetting);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteShareSettingAsync(int id)
        {
            ShareSetting shareSetting = await _unitOfWork.ShareSettingDal.GetAsync(p => p.Id == id);
            await _unitOfWork.ShareSettingDal.DeleteAsync(shareSetting);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<ShareSettingDto>> GetAllShareSettingsAsync()
        {
            List<ShareSetting> shareSettings = await _unitOfWork.ShareSettingDal.GetAllAsync();
            List<ShareSettingDto> shareSettingDtos = new List<ShareSettingDto>();
            foreach (ShareSetting shareSetting in shareSettings)
            {
                shareSettingDtos.Add(new ShareSettingDto()
                {
                    NoteId = shareSetting.Id,
                    IsPublic = shareSetting.IsPublic,
                    IsFriendsOnly = shareSetting.IsFriendsOnly,
                    Id = shareSetting.Id,



                });
            }
            return shareSettingDtos;
        }

        public async Task<ShareSettingDto> GetShareSettingByIdAsync(int id)
        {
            ShareSetting shareSetting = await _unitOfWork.ShareSettingDal.GetAsync(x => x.Id == id);
            return new ShareSettingDto()
            {
                Id = shareSetting.Id,
                IsFriendsOnly = shareSetting.IsFriendsOnly,
                IsPublic = shareSetting.IsPublic,
                NoteId = shareSetting.Id,

            };
        }

        public async Task<int> UpdateShareSettingAsync(ShareSettingDto shareSettingDto)
        {
            ShareSetting shareSetting = await _unitOfWork.ShareSettingDal.GetAsync(x => x.Id == shareSettingDto.Id);
            shareSetting.Id = shareSettingDto.Id;
            shareSetting.IsFriendsOnly = shareSettingDto.IsFriendsOnly;
            shareSetting.IsPublic = shareSettingDto.IsPublic;
            shareSetting.NoteId = shareSettingDto.NoteId;


            await _unitOfWork.ShareSettingDal.UpdateAsync(shareSetting);
            return await _unitOfWork.SaveAsync();
        }
    }
}
