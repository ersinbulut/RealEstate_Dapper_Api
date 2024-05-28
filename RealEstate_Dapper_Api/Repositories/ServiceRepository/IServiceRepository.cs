using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto ServiceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto ServiceDto);
        Task<GetByIDServiceDto> GetService(int id);
    }
}
