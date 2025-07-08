using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class StaffService
    {
        private readonly IMongoCollection<Staff> _staff;

        public StaffService(IConfiguration configuration)
        {
            var database = DBHelper.GetDatabase(configuration);
            _staff = database.GetCollection<Staff>("staff");
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _staff.Find(_ => true).ToListAsync();
        }

        public async Task<Staff> GetByIdAsync(string id)
        {
            return await _staff.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Staff staff)
        {
            await _staff.InsertOneAsync(staff);
        }

        public async Task UpdateAsync(Staff staff)
        {
            await _staff.ReplaceOneAsync(s => s.Id == staff.Id, staff);
        }

        public async Task DeleteAsync(string id)
        {
            await _staff.DeleteOneAsync(s => s.Id == id);
        }
    }
}
