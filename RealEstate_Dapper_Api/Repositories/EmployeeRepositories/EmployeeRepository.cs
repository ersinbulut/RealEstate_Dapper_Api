using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto EmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values (@Name,@Title,@Mail,@PhoneNumber,@ImageUrl,@Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", EmployeeDto.Name);
            parameters.Add("@Title", EmployeeDto.Title);
            parameters.Add("@Mail", EmployeeDto.Mail);
            parameters.Add("@PhoneNumber", EmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", EmployeeDto.ImageUrl);
            parameters.Add("@Status", EmployeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * from Employee where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            string query = "Update Employee Set Name=@Name,Title=@Title,Mail=@Mail,PhoneNumber=@PhoneNumber,ImageUrl=@ImageUrl,Status=@Status where EmployeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", EmployeeDto.Name);
            parameters.Add("@Title", EmployeeDto.Title);
            parameters.Add("@Mail", EmployeeDto.Mail);
            parameters.Add("@PhoneNumber", EmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", EmployeeDto.ImageUrl);
            parameters.Add("@Status", EmployeeDto.Status);
            parameters.Add("@employeeID", EmployeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
