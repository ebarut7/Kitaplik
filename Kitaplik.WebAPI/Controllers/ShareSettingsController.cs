using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareSettingsController : ControllerBase
    {
        private readonly IShareSettingService _shareSettingService;

        public ShareSettingsController(IShareSettingService shareSettingService)
        {
            _shareSettingService = shareSettingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ShareSettingDto shareSettingDto = await _shareSettingService.GetShareSettingByIdAsync(id);
            return Ok(shareSettingDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ShareSettingDto> shareSettingDtos= await _shareSettingService.GetAllShareSettingsAsync();
            return shareSettingDtos is not null ? Ok(shareSettingDtos) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddShareSetting(ShareSettingDto shareSettingDto)
        {
            int response = await _shareSettingService.AddShareSettingAsync(shareSettingDto);
            return response > 0 ? Ok(response) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShareSetting(ShareSettingDto shareSettingDto)
        {
            int response = await _shareSettingService.UpdateShareSettingAsync(shareSettingDto);
            return response > 0 ? Ok("Güncelleme başarılı")  : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (int id)
        {
            int response = await _shareSettingService.DeleteShareSettingAsync(id);
            return response > 0 ? Ok(response) :NotFound();
        }
    }
}
