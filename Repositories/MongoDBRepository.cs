using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://brayan:1233903743@brayan.urcpd.mongodb.net/Solicitudes?retryWrites=true&w=majority");

            db = client.GetDatabase("Solicitudes");
        }
    }
}
