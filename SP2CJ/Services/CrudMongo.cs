using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.FSharp.Collections;
using Microsoft.VisualBasic;

namespace SP2CJ.Services;

public class CrudMongo
{
    private IMongoCollection<Jemaat> JemaatCollection()
    {
        var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(DatabaseSetting.DatabaseName);
        var collection = database.GetCollection<Jemaat>(DatabaseSetting.JemaatCollectionName);
        return collection;
    }

    private IMongoCollection<RefRole> RefRoleCollection()
    {
        var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(DatabaseSetting.DatabaseName);
        var collection = database.GetCollection<RefRole>(DatabaseSetting.RefRoleCollectionName);
        return collection;
    }

    private IMongoCollection<Jemaat> JadwalCollection()
    {
        var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(DatabaseSetting.DatabaseName);
        var collection = database.GetCollection<Jemaat>(DatabaseSetting.JadwalCollectionName);
        return collection;
    }

    private IMongoCollection<RefMaster> RefMasterCollection()
    {
        var settings = MongoClientSettings.FromConnectionString(DatabaseSetting.ConnectionString);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(DatabaseSetting.DatabaseName);
        var collection = database.GetCollection<RefMaster>(DatabaseSetting.RefMasterCollectionName);
        return collection;
    }

    public String InputRefRole(List<RefRole> refRoles)
    {
        CrudMongo cm = new CrudMongo();
        String message = String.Empty;
        var Ref = GetRefMaster("PLYAN");

        refRoles = (from rr in refRoles
                    join a in Ref.ItemList on rr.RoleType.itemCode equals a.itemCode
                    select new RefRole()
                    {
                        RoleCode = rr.RoleCode,
                        RoleName = rr.RoleName,
                        RoleType = a
                    }).ToList();

        var collection = cm.RefRoleCollection();
        try
        {
            collection.InsertMany(refRoles);
        }
        catch
        {
            message = "Role Code tidak boleh duplikat";
        }
        return message;
    }

    public List<RefRole> GetRefRoles()
    {
        var collection = RefRoleCollection();
        var List = collection.Find(a => a.RoleName != null).ToList();
        return List;
    }

    public bool DeleteRole(RefRole delete)
    {
        var collection = RefRoleCollection();
        return collection.DeleteOne(delete.ToBsonDocument()).IsAcknowledged;
    }

    public RefMaster GetRefMaster(string RMCode)
    {
        var collection = RefMasterCollection();
        var returned = collection.Find(a => a.RefMasterCode.Equals(RMCode)).FirstOrDefault();

        return returned;
    }

    public void EditRefMasterItem(RefMaster Edited)
    {
        var filter = Builders<RefMaster>.Filter.Eq(master => master.Id, Edited.Id);
        var update = Builders<RefMaster>.Update.Set(master => master.ItemList, Edited.ItemList);
        var collection = RefMasterCollection();
        collection.UpdateOne(filter, update);
    }

    public Task InsertJemaats(List<Jemaat> insertedJemaats)
    {
        if (!insertedJemaats.Any()) return Task.CompletedTask;
        var collection = JemaatCollection();
        collection.InsertMany(insertedJemaats);
        return Task.CompletedTask;
    }

    private List<Jemaat> GetAllJemaat =
        Collections.JemaatCollection().Find(a => true).ToList();


    public List<Jemaat> GetAvailable(DateTime tanggal)
    {
        var unavail = Collections.JadwalCollection().Find(a => a.tanggal == tanggal).ToList();
        var listJemaat = unavail.SelectMany(a => a.Pelayans.Select(a => a.Jemaat.Id));
        return Collections.JemaatCollection().Find(a => !listJemaat.Contains(a.Id)).ToList();
    }

    public Dictionary<string, List<Jemaat>> pelayansSorted(DateTime tanggal)
    {
        Dictionary<string, List<Jemaat>> returned = new();
        FSMerged fs = new FSMerged();
        var listRoleType = fs.GetRefMasterItems("PLYAN").ItemList;

        var Pelayans = GetAvailable(tanggal);

        for (int a = 0; a < listRoleType.Count(); a++)
        {
            var roleType = listRoleType[a].itemCode;
            if (roleType != null)
                returned[roleType] = Pelayans.Where(alinq => alinq.Roles.Any(x => x.RoleType.itemCode == roleType)).ToList();
        }
        return returned;
    }

    public Task submitJadwal(Jadwal baru)
    {
        try
        {
            Collections.JadwalCollection().InsertOne(baru);
            return Task.CompletedTask;

        }
        catch
        {
            return Task.FromCanceled(CancellationToken.None);
        }
    }

    public List<Jadwal> GetJadwals(DateTime min, DateTime max)
    {
        return Collections.JadwalCollection().Find(a => a.tanggal >= min && a.tanggal <= max).ToList();
    }

    public void InputRenungan(Renungan renung)
    {
        Collections.RenunganCollection().InsertOne(renung);

    }

    public List<Renungan> BacaBoiHariIni()
    {
        return Collections.RenunganCollection().Find(a => a.Tanggal == DateTime.Now).ToList();
    }
}