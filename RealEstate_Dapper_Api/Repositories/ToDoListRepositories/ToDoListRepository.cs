using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDoList(CreateToDoListDto ToDoListDto)
        {
            string query = "insert into ToDoList (Description,ToDoListStatus) values (@description,@todolistStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", ToDoListDto.Description);
            parameters.Add("@todolistStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteToDoList(int id)
        {
            string query = "Delete From ToDoList Where ToDoListID=@ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            string query = "Select * from ToDoList where ToDoListID=@ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateToDoList(UpdateToDoListDto toDoListDto)
        {
            string query = "Update ToDoList Set Description=@Description,ToDoListStatus=@ToDoListStatus where ToDoListID=@ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", toDoListDto.Description);
            parameters.Add("@ToDoListStatus", toDoListDto.ToDoListStatus);
            parameters.Add("@ToDoListID", toDoListDto.ToDoListID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
