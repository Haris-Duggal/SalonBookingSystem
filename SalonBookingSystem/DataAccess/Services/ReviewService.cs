using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewService(IConfiguration configuration)
        {
            var database = DBHelper.GetDatabase(configuration);
            _reviews = database.GetCollection<Review>("reviews");
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _reviews.Find(_ => true).ToListAsync();
        }

        public async Task<Review> GetByIdAsync(string id)
        {
            return await _reviews.Find(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _reviews.InsertOneAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            await _reviews.ReplaceOneAsync(r => r.Id == review.Id, review);
        }

        public async Task DeleteAsync(string id)
        {
            await _reviews.DeleteOneAsync(r => r.Id == id);
        }
    }
}
