using MongoDB.Driver;

namespace Models
{
    public class Collections
    {
        public static IMongoCollection<Jemaat> JemaatCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Jemaat>(DatabaseSetting.JemaatCollectionName);
            return collection;
        }

        public static IMongoCollection<RefRole> RefRoleCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<RefRole>(DatabaseSetting.RefRoleCollectionName);
            return collection;
        }

        public static IMongoCollection<Jemaat> JadwalCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Jemaat>(DatabaseSetting.JadwalCollectionName);
            return collection;
        }

        public static IMongoCollection<RefMaster> RefMasterCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<RefMaster>(DatabaseSetting.RefMasterCollectionName);
            return collection;
        }
    }


}
