using MongoDB.Driver;
using SalonBookingSystem.Models;

namespace SalonBookingSystem.DataAccess.Services
{
    public class SkillService
    {
        private readonly IMongoCollection<Skill> _skills;

        public SkillService()
        {
            var database = DBHelper.GetDatabase();
            _skills = database.GetCollection<Skill>("skills");
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _skills.Find(_ => true).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(string id)
        {
            return await _skills.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Skill skill)
        {
            await _skills.InsertOneAsync(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
            await _skills.ReplaceOneAsync(s => s.Id == skill.Id, skill);
        }

        public async Task DeleteAsync(string id)
        {
            await _skills.DeleteOneAsync(s => s.Id == id);
        }
    }
}
