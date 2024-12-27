using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region İstatistik1
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7285/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonData;
            #endregion
            #region İstatistik2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7285/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData;
            #endregion
            #region İstatistik3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("https://localhost:7285/api/Statistics/ApartmenCount");
            var jsonData3 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ApartmenCount = jsonData;
            #endregion
            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client.GetAsync("https://localhost:7285/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonData;
            #endregion
            #region İstatistik5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client.GetAsync("https://localhost:7285/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceBySale = jsonData;
            #endregion
            #region İstatistik6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client.GetAsync("https://localhost:7285/api/Statistics/AverageRoomCount");
            var jsonData6 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonData;
            #endregion
            #region İstatistik7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client.GetAsync("https://localhost:7285/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData;
            #endregion
            #region İstatistik8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client.GetAsync("https://localhost:7285/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData;
            #endregion
            #region İstatistik9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client.GetAsync("https://localhost:7285/api/Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData;
            #endregion
            #region İstatistik10
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("https://localhost:7285/api/Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData;
            #endregion
            #region İstatistik11
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client.GetAsync("https://localhost:7285/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData;
            #endregion
            #region İstatistik12
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client.GetAsync("https://localhost:7285/api/Statistics/LastProductPrice");
            var jsonData12 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData;
            #endregion
            #region İstatistik13
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client.GetAsync("https://localhost:7285/api/Statistics/NewestBuildingYear");
            var jsonData13 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonData;
            #endregion
            #region İstatistik14
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client.GetAsync("https://localhost:7285/api/Statistics/OldestBuildingYear");
            var jsonData14 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonData;
            #endregion
            #region İstatistik15
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client.GetAsync("https://localhost:7285/api/Statistics/ProductCount");
            var jsonData15 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData;
            #endregion  

            return View();
        }
    }
}
