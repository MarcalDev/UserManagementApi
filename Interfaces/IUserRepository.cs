using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;

namespace UserManagementApi.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(Guid id);
        public Task<User> UserAuthentication(string email, string password);
        public Task<int> PostUser(User user);
    }
}
