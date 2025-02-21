using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("https://localhost:7285/api/Products/ProductListWithCategory");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("https://localhost:7285/api/Products/GetProductByProductId?id=" + id);
            var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDtos>(jsonData);

            var responsiveMessage2 = await client.GetAsync("https://localhost:7285/api/ProductDetails/GetProductDetailByProductID?id=" + id);
            var jsonData2 = await responsiveMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

            ViewBag.productId = values.productID.ToString();
            ViewBag.title1 = values.title.ToString();
            ViewBag.price = values.price.ToString();
            ViewBag.city = values.city.ToString();
            ViewBag.district = values.district.ToString();
            ViewBag.address = values.address.ToString();
            ViewBag.type = values.type.ToString();
            ViewBag.description = values.description;
            ViewBag.datediff = values.address.ToString();

            ViewBag.bathCount = values2.bathCount;
            ViewBag.bedCount = values2.bedRoomCount;
            ViewBag.size = values2.productSize;
            ViewBag.roomCount = values2.roomCount;
            ViewBag.garageCount = values2.garageSize;
            ViewBag.buildYear = values2.buildYear;
            ViewBag.date = values.AdvertisementDate;

            DateTime date1=DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timeSpan=date1-date2;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;


            return View(values);

        }
    }
}
