using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopulerLocation();
        Task CreatePopulerLocation(CreatePopulerLocationDto PopulerLocationDto);
        Task DeletePopulerLocation(int id);
        Task UpdatePopulerLocation(UpdatePopulerLocationDto PopulerLocationDto);
        Task<GetByIDPopulerLocationDto> GetPopulerLocation(int id);
    }
}
