using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PopulerLocationList()
        {
            var values = await _popularLocationRepository.GetAllPopulerLocationAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopulerLocation(CreatePopulerLocationDto createPopulerLocationDto)
        {
            _popularLocationRepository.CreatePopulerLocation(createPopulerLocationDto);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopulerLocation(int id)
        {
            _popularLocationRepository.DeletePopulerLocation(id);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopulerLocation(UpdatePopulerLocationDto updatePopulerLocationDto)
        {
            _popularLocationRepository.UpdatePopulerLocation(updatePopulerLocationDto);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopulerLocation(int id)
        {
            var value = await _popularLocationRepository.GetPopulerLocation(id);
            return Ok(value);
        }
    }
}
