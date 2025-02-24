using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopulerLocation(CreatePopulerLocationDto populerLocationDto)
        {
            string query = "insert into PopulerLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", populerLocationDto.CityName);
            parameters.Add("@imageUrl", populerLocationDto.ImageUrl);
        
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopulerLocation(int id)
        {
            string query = "Delete From PopulerLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopulerLocation()
        {
            string query = "Select * From PopulerLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopulerLocationDto> GetPopulerLocation(int id)
        {
            string query = "Select * from PopulerLocation where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopulerLocationDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdatePopulerLocation(UpdatePopulerLocationDto populerLocationDto)
        {
            string query = "Update PopulerLocation Set CityName=@cityName,ImageUrl=@imageUrl where LocationID=@LocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", populerLocationDto.CityName);
            parameters.Add("@imageUrl", populerLocationDto.ImageUrl);
            parameters.Add("@LocationID", populerLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

 
    }
}
