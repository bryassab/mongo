using Mongodb.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Repositories
{
    interface INSolicitudCollection
    {
        Task InsertSolicitud(SolicitudModal Solicitud);
        Task UpdateSolicitud(SolicitudModal Solicitud);
        Task DeleteSolicitud(string id);
        Task<List<SolicitudModal>> GetAllSolicitudes();
        Task<SolicitudModal> GetSolicitudById(string id);
    }
}
