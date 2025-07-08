using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class BookingService
    {
        private readonly IMongoCollection<Booking> _bookings;

        public BookingService(IConfiguration configuration)
        {
            var database = DBHelper.GetDatabase(configuration);
            _bookings = database.GetCollection<Booking>("bookings");
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _bookings.Find(_ => true).ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(string id)
        {
            return await _bookings.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await _bookings.InsertOneAsync(booking);
        }

        public async Task UpdateAsync(Booking booking)
        {
            await _bookings.ReplaceOneAsync(b => b.Id == booking.Id, booking);
        }

        public async Task DeleteAsync(string id)
        {
            await _bookings.DeleteOneAsync(b => b.Id == id);
        }
    }
}
