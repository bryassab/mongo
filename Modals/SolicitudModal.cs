using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Modals
{
    public class SolicitudModal
    {
        [BsonId]   
        public ObjectId Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } 
        public int Presupuesto_Solicitado { get; set; }
        public string Division { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Responsable { get; set; }
        public string Estado { get; set; }
        
        
        }

}
