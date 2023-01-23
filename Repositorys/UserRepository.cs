using Dapper;
using UserManagementApi.Interfaces;
using UserManagementApi.Models;

namespace UserManagementApi.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var query = "SELECT * FROM USERS";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users.ToList();
            }
        }

        public async Task<User> GetUserById(Guid id)
        {
            var query = $"SELECT * FROM USERS WHERE Id = '{id}'";

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(query);
                return user;
            }
        }

        public async Task<User> UserAuthentication(string email, string password)
        {
            var query = $"SELECT * FROM USERS WHERE Email = '{email}' AND Password = '{password}'";

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(query);
                return user;
            }
        }

        public async Task<User> PostUser(User user)
        {
            var query = "INSERT INTO USERS (Id,Name,Email,PhoneNumber,Password,RealeaseDate,isActive) VALUES " +
                $"('{user.Id}', '{user.Name}', '{user.Email}','{user.PhoneNumber}', '{user.Password}', '{user.RealeaseDate}', 1)";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>(query);                
                return result;
            }
        }


    }
}
