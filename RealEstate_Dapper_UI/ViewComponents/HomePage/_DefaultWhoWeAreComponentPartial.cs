using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient()
                ;
            var responsiveMessage = await client.GetAsync("https://localhost:7285/api/WhoWeAreDetail");
            var responsiveMessage2 = await client.GetAsync("https://localhost:7285/api/Services");

            if (responsiveMessage.IsSuccessStatusCode && responsiveMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responsiveMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.title=value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subTitle=value.Select(x=>x.Subtitle).FirstOrDefault();
                ViewBag.description1=value.Select(x=>x.Description1).FirstOrDefault();
                ViewBag.description2=value.Select(x=>x.Description2).FirstOrDefault();
                return View(value2);
            }
               return View();
        }
    }
}
