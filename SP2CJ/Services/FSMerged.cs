using Blazorise;
using static SP2CJ.Services.Models;
using MongoDB.Driver;

namespace SP2CJ.Services
{
    public class FSMerged
    {
        public List<Jemaat> ListAllJemaat()
        {
            return Collections.JemaatCollection().Find(a => true).ToList();
        }

        public DeleteResult? DeleteJemaat(Jemaat jemaatDiKill)
        {
            var filter = Builders<Jemaat>.Filter.Eq((x => x.Id), jemaatDiKill.Id);
            return Collections.JemaatCollection().DeleteOne(filter);
        }

        public Jemaat? editJemaat(Jemaat jemaatEdit)
        {
            var filter = Builders<Jemaat>.Filter.Eq((x => x.Id), jemaatEdit.Id);
            return Collections.JemaatCollection().FindOneAndReplace(filter, jemaatEdit);
        }

        public RefMaster GetRefMasterItems(string Code)
        {
            return Collections.RefMasterCollection().Find(a => a.RefMasterCode == Code).First();
        }


    }
}
