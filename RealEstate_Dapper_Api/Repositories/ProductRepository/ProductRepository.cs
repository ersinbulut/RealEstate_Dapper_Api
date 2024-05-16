using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProductAsync(CreateProductDto ProductDto)
        {
            string query = "insert into Product (ProductTitle,ProductPrice,ProductCity,ProductDistrict) values (@ProductTitle,@ProductPrice,@ProductCity,@ProductDistrict)";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductTitle", ProductDto.Title);
            parameters.Add("@ProductPrice", ProductDto.Price);
            parameters.Add("@ProductCity", ProductDto.City);
            parameters.Add("@ProductDistrict", ProductDto.District);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteProduct(int id)
        {
            string query = "Delete From Product Where ProductID=@produtID";
            var parameters = new DynamicParameters();
            parameters.Add("@produtID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName From Product inner join Category on" +
                "Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDProductDto> GetProduct(int id)
        {
            string query = "Select * from Product where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDProductDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateProduct(UpdateProductDto ProductDto)
        {
            string query = "Update Product Set ProductTitle=@ProductTitle,ProductPrice=@ProductPrice,ProductCity=@ProductCity,ProductDistrict=@ProductDistrict where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductTitle", ProductDto.Title);
            parameters.Add("@ProductPrice", ProductDto.Price);
            parameters.Add("@ProductCity", ProductDto.City);
            parameters.Add("@ProductDistrict", ProductDto.District);
            parameters.Add("@ProductID", ProductDto.ProductID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
