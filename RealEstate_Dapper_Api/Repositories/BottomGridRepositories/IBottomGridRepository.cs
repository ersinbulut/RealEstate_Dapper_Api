using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto BottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto BottomGridDto);
        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
