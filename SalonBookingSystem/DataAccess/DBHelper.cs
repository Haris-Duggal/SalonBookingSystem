using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace SalonBookingSystem.DataAccess
{
    public class DBHelper
    {
        private static IMongoDatabase? _database;

        public static IMongoDatabase GetDatabase(IConfiguration configuration)
        {
            if (_database == null)
            {
                string connectionString = configuration.GetConnectionString("MongoDb");
                string databaseName = "SaloonDatabase";

                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(databaseName);
            }

            return _database;
        }
    }
}
