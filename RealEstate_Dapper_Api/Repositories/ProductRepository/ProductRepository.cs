﻿using Dapper;
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
            string query = "insert into Product (Title,Price,City,District) values (@Title,@Price,@City,@District)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", ProductDto.Title);
            parameters.Add("@Price", ProductDto.Price);
            parameters.Add("@City", ProductDto.City);
            parameters.Add("@District", ProductDto.District);
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

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsync(int id)
        {
            string query = @"SELECT 
            ProductID, Title, Price, City, District, 
            CategoryName, CoverImage, Type, Address, DealOfTheDay 
            FROM Product 
            INNER JOIN Category ON Product.ProductCategory = Category.CategoryID 
            WHERE EmployeeID = @employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) // Bağlantıyı oluştur
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }


        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
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
