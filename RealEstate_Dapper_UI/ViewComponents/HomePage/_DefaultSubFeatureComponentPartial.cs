using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("https://localhost:7285/api/SubFeatures/");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
