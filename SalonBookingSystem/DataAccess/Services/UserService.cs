using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration configuration)
        {
            var database = DBHelper.GetDatabase(configuration);
            _users = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(string id)
        {
            await _users.DeleteOneAsync(u => u.Id == id);
        }

        public async Task<User> ValidateLoginAsync(string email, string password)
        {
            return await _users.Find(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }

    }
}
