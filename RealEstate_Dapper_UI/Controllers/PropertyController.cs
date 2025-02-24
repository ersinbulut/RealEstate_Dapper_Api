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

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync($"https://localhost:7285/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug,int id)
        {
            ViewBag.i = id;
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
            ViewBag.slugUrl=values.slugurl;

            ViewBag.bathCount = values2.bathCount;
            ViewBag.bedCount = values2.bedRoomCount;
            ViewBag.size = values2.productSize;
            ViewBag.roomCount = values2.roomCount;
            ViewBag.garageCount = values2.garageSize;
            ViewBag.buildYear = values2.buildYear;
            ViewBag.date = values.AdvertisementDate;
            ViewBag.location = values2.location;
            ViewBag.videoUrl = values2.videoUrl;

           DateTime date1=DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timeSpan=date1-date2;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;

            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slagUrl = slugFromTitle;
            return View(values);
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir
            return title;
        }


    }
}
