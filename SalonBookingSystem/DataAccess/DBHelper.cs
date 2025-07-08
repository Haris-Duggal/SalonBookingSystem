using MongoDB.Driver;

namespace SalonBookingSystem.DataAccess
{
    public class DBHelper
    {
        private static readonly string connectionString = "mongodb+srv://haris:2vcjvo99C@saloncluster.nrnykly.mongodb.net/?retryWrites=true&w=majority&appName=SalonCluster";
        private static readonly string databaseName = "SaloonDatabase";

        public static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}
