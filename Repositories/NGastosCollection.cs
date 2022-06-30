using Mongodb.Modals;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Repositories
{
    public class NGastosCollection : INGastosCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<GastosModal> Collection;

        public NGastosCollection()
        {
            Collection = _repository.db.GetCollection<GastosModal>("Gastos");
        }
        public async Task DeleteGasto(string id)
        {
            var filter = Builders<GastosModal>.Filter.Eq(x => x.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<GastosModal>> GetAllGastos()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<GastosModal> GetGastoById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertGasto(GastosModal Gasto)
        {
            await Collection.InsertOneAsync(Gasto);
        }

        public async Task UpdateGasto(GastosModal Gasto)
        {
            var filter = Builders<GastosModal>.Filter.Eq(x => x.Id, Gasto.Id);
            await Collection.ReplaceOneAsync(filter, Gasto);
        }
    }
}
