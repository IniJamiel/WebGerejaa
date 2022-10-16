using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SP2CJ.Services
{
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

        public static string MiscelanousCollectionName { get; set; } = "Miscelanous";
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

        public int SortPrio = 1;
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


        public Dictionary<string, List<Pelayan>> PelayansJadwal = new();

        public List<Pelayan> Pelayans => PelayansJadwal.SelectMany(a => a.Value).ToList();
        public String Tema { set; get; }
    }

    public class Pelayan
    {
        public Pelayan(RefRole role, Jemaat jemaat, string roleCode)
        {
            Role = role;
            Jemaat = jemaat;
            RoleCode = roleCode;
        }
        public string RoleCode { set; get; }
        public Jemaat Jemaat { set; get; }
        public RefRole Role { set; get; }
    }

    public class Renungan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Judul;
        public string Isi;
        public string penulis;
        public DateTime Tanggal;
    }

    public class Dudu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Dari;
        public string Untuk;
        public string Pesan;
        public DateTime Tanggal;
    }
    public class Pengumuman
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Judul;
        public string Isi;
        public DateTime Tanggal;
    }

    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Judul;
        public string Isi;
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

        public static readonly RefMasterItem AllRefMaster = new() { Id = "ALl", itemCode = "All", itemName = "All" };

    }

}
