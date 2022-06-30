using Mongodb.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Repositories
{
    interface INGastosCollection
    {
        Task InsertGasto(GastosModal Gasto);
        Task UpdateGasto(GastosModal Gasto);
        Task DeleteGasto(string id);
        Task<List<GastosModal>> GetAllGastos();
        Task<GastosModal> GetGastoById(string id);

    }
}
