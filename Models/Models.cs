using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class Models
{

}

public class DatabaseSetting
{
    public static string ConnectionString { get; set; } = "mongodb+srv://Jamiel:Jamiel@sp2cj.tmh2aki.mongodb.net/?retryWrites=true&w=majority";
    public static string DatabaseName { get; set; } = "SP2CJ";
    public static string JemaatCollectionName { get; set; } = "Jemaat";
    public static string RefRoleCollectionName { get; set; } = "RefRole";
    public static string JadwalCollectionName { get; set; } = "Jadwal";
    public static string RefMasterCollectionName { get; set; } = "RefMaster";
}

public class Jemaat
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [Required(ErrorMessage = "Required")]
    public string Name { get; set; } = null!;

    public string Username { get; set; }

    [Required(ErrorMessage = "Nama Lengkap Perlu Diisi")]
    public string FullName { get; set; } = null!;

    public RefMasterItem Jabatan { get; set; } = new RefMasterItem();
    public List<RefRole> Roles { get; set; } = new List<RefRole>();

    [DataType(DataType.PhoneNumber)] public string nomorHandphone { get; set; }
    public string idLine { get; set; }

}

public class RefRole
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("Name")]
    [Required]
    public string RoleName { get; set; } = null!;
    [Required]
    public string RoleCode { get; set; }
    public RefMasterItem RoleType { get; set; } = new RefMasterItem();

    public string TypeName => RoleType.itemName;
}

public class Jadwal
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String? Id { get; set; }
    [BsonElement("Name")]
    public String JadwalName { get; set; } = null!;
    public DateTime tanggal { get; set; }
    public String JenisJadwal { get; set; } = null!;

    public List<Pelayan> Pelayans {
        set;
        get;
    }

    public String Tema { set; get; }
    public List<string> GetPelayan => Pelayans.Select(a => a.JemaatId).ToList();
}

public class Pelayan
{
    public String JemaatId { set; get; }
    public String RoleId { set; get; }
}


public class RefMaster
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [MaxLength(5)]
    public string RefMasterCode { get; set; } = null!;
    [MaxLength(30)]
    public string RefMasterName { get; set; }

    public string RefMasterDescription { set; get; } = "";

    public List<RefMasterItem> ItemList
    {
        get;
        set;
    }
}

public class RefMasterItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    public string? itemCode { get; set; }
    [Required]
    public string itemName { get; set; }
}

