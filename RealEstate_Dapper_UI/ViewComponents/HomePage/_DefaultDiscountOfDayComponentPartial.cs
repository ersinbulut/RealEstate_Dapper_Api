using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultDiscountOfDayComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultDiscountOfDayComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("https://localhost:7285/api/Products/GetLast3Product");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
