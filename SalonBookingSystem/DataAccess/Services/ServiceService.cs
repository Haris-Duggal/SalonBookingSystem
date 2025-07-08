using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class ServiceService
    {
        private readonly IMongoCollection<Service> _services;

        public ServiceService(IConfiguration configuration)
        {
            var database = DBHelper.GetDatabase(configuration);
            _services = database.GetCollection<Service>("services");
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _services.Find(_ => true).ToListAsync();
        }

        public async Task<Service> GetByIdAsync(string id)
        {
            return await _services.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Service service)
        {
            await _services.InsertOneAsync(service);
        }

        public async Task UpdateAsync(Service service)
        {
            await _services.ReplaceOneAsync(s => s.Id == service.Id, service);
        }

        public async Task DeleteAsync(string id)
        {
            await _services.DeleteOneAsync(s => s.Id == id);
        }
    }
}
