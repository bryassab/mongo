using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Modals
{
    public class GastosModal
    {
        [BsonId]

        public ObjectId Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Proveedor { get; set; }
        public int Alimentacion { get; set; }
        public int Transportes { get; set; }
        public int Hotel { get; set; }
        public int Otros { get; set; }
        public int Total { get; set; }

    }
}
