using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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

        public async Task CreateProduct(CreateProductDto ProductDto)
        {
            string query = "insert into Product (Title,Price,City,District,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,EmployeeID) values (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", ProductDto.Title);
            parameters.Add("@Price", ProductDto.Price);
            parameters.Add("@City", ProductDto.City);
            parameters.Add("@District", ProductDto.District);
            parameters.Add("@CoverImage", ProductDto.CoverImage);
            parameters.Add("@Address", ProductDto.Address);
            parameters.Add("@Description", ProductDto.Description);
            parameters.Add("@Type", ProductDto.Type);
            parameters.Add("@DealOfTheDay", ProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", ProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", ProductDto.ProductStatus);
            parameters.Add("@ProductCategory", ProductDto.ProductCategory);
            parameters.Add("@EmployeeID", ProductDto.EmployeeID);
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
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID, Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate\r\nFrom Product Inner Join Category\r\nOn Product.ProductCategory = Category.CategoryID\r\nWhere Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
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

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {

            string query = @"SELECT 
            ProductID, Title, Price, City, District, 
            CategoryName, CoverImage, Type, Address, DealOfTheDay 
            FROM Product 
            INNER JOIN Category ON Product.ProductCategory = Category.CategoryID 
            WHERE EmployeeID = @employeeId and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) // Bağlantıyı oluştur
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = @"SELECT 
            ProductID, Title, Price, City, District, 
            CategoryName, CoverImage, Type, Address, DealOfTheDay 
            FROM Product 
            INNER JOIN Category ON Product.ProductCategory = Category.CategoryID 
            WHERE EmployeeID = @employeeId and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) // Bağlantıyı oluştur
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIDDto> GetProductByProductID(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIDDto>(query,parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductID(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateProduct(UpdateProductDto ProductDto)
        {
            string query = "Update Product Set Title=@Title,Price=@Price,City=@City,District=@District where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", ProductDto.Title);
            parameters.Add("@Price", ProductDto.Price);
            parameters.Add("@City", ProductDto.City);
            parameters.Add("@District", ProductDto.District);
            parameters.Add("@ProductID", ProductDto.ProductID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
