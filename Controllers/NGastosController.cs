using Microsoft.AspNetCore.Mvc;
using Mongodb.Modals;
using Mongodb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NGastosController : Controller
    {
        private INGastosCollection db = new NGastosCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllGastos()
        {
            return Ok(await db.GetAllGastos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGastosDetail(string id)
        {
            return Ok(await db.GetGastoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGasto([FromBody] GastosModal Gasto)
        {
            if (Gasto == null)
                return BadRequest();

            if (Gasto.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no puede estar vacio");
            }
            await db.InsertGasto(Gasto);
            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGasto([FromBody] GastosModal Gasto, string id)
        {
            if (Gasto == null)
                return BadRequest();

            if (Gasto.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no puede estar vacio");
            }
            Gasto.Id =new MongoDB.Bson.ObjectId (id);
            await db.UpdateGasto(Gasto);
            return Created("Creado", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGasto(string id)
        {
            await db.DeleteGasto(id);
            return NoContent();
        }

    }
}
