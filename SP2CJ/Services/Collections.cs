using MongoDB.Driver;

namespace SP2CJ.Services
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

        public static IMongoCollection<Jadwal> JadwalCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Jadwal>(DatabaseSetting.JadwalCollectionName);
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

        public static IMongoCollection<Dudu> DuduCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Dudu>(DatabaseSetting.MiscelanousCollectionName);
            return collection;
        }

        public static IMongoCollection<Pengumuman> Pengumumanollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Pengumuman>(DatabaseSetting.MiscelanousCollectionName);
            return collection;
        }

        public static IMongoCollection<Renungan> RenunganCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<Renungan>(DatabaseSetting.MiscelanousCollectionName);
            return collection;
        }

        public static IMongoCollection<About> AboutCollection()
        {
            var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(DatabaseSetting.DatabaseName);
            var collection = database.GetCollection<About>(DatabaseSetting.MiscelanousCollectionName);
            return collection;

        }
    }
}
