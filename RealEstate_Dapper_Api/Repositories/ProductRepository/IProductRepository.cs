using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        void CreateProductAsync(CreateProductDto ProductDto);
        void DeleteProduct(int id);
        void UpdateProduct(UpdateProductDto ProductDto);
        Task<GetByIDProductDto> GetProduct(int id);
    }
}
