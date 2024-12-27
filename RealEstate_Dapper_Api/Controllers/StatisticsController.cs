using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        //aktif kategori sayısı
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_statisticsRepository.ActiveCategoryCount());
        }
        //aktif personel sayısı
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statisticsRepository.ActiveEmployeeCount());
        }
        //daire sayısı
        [HttpGet("ApartmenCount")]
        public IActionResult ApartmenCount()
        {
            return Ok(_statisticsRepository.ApartmenCount());
        }
        //satılıkların ortalama fiyatı
        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            return Ok(_statisticsRepository.AverageProductPriceByRent());
        }
        //kiralıkların ortalama fiyatı
        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            return Ok(_statisticsRepository.AverageProductPriceBySale());
        }
        //ortalama oda sayısı
        [HttpGet("AverageRoomCount")]
        public IActionResult AverageRoomCount()
        {
            return Ok(_statisticsRepository.AverageRoomCount());
        }
        //kategori sayısı
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statisticsRepository.CategoryCount());
        }
      
        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            return Ok(_statisticsRepository.CategoryNameByMaxProductCount());
        }

        //ŞehirAdıMaksimumÜrünSayısına Göre
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(_statisticsRepository.CategoryNameByMaxProductCount());
        }

       [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(_statisticsRepository.DifferentCityCount());
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
        {
            return Ok(_statisticsRepository.EmployeeNameByMaxProductCount());
        }

        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            return Ok(_statisticsRepository.LastProductPrice());
        }

        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            return Ok(_statisticsRepository.NewestBuildingYear());
        }

        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            return Ok(_statisticsRepository.OldestBuildingYear());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_statisticsRepository.ProductCount());
        }
    }
}
