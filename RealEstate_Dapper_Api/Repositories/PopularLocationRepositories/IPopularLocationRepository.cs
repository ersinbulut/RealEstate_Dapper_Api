using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopulerLocationAsync();
        //void CreatePopulerLocation(CreatePopulerLocationDto PopulerLocationDto);
        //void DeletePopulerLocation(int id);
        //void UpdatePopulerLocation(UpdatePopulerLocationDto PopulerLocationDto);
        //Task<GetPopulerLocationDto> GetPopulerLocation(int id);
    }
}
