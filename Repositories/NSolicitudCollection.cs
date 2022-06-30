using Mongodb.Modals;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Repositories
{
    public class NSolicitudCollection : INSolicitudCollection
    {
        internal MongoDBRepository _Srepository = new MongoDBRepository();
        private IMongoCollection<SolicitudModal> Collection;

        public NSolicitudCollection()
        {
            Collection = _Srepository.db.GetCollection<SolicitudModal>("Solicitud");
        }
        public async Task DeleteSolicitud(string id)
        {
            var filter = Builders<SolicitudModal>.Filter.Eq(x => x.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<SolicitudModal>> GetAllSolicitudes()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<SolicitudModal> GetSolicitudById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync(); 
        }

        public async Task InsertSolicitud(SolicitudModal Solicitud)
        {
            await Collection.InsertOneAsync(Solicitud);
        }

        public async Task UpdateSolicitud(SolicitudModal Solicitud)
        {
            var filter = Builders<SolicitudModal>.Filter.Eq(x => x.Id, Solicitud.Id);
            await Collection.ReplaceOneAsync(filter, Solicitud);
        }
    }
}
