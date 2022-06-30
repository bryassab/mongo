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
    public class SolicitudesController : Controller
    {
        private INSolicitudCollection db = new NSolicitudCollection();
        
        [HttpGet]
        public async Task<IActionResult> GetAllSolicitudes()
        {
            return Ok(await db.GetAllSolicitudes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSolicitudesDetail(string id)
        {
            return Ok(await db.GetSolicitudById(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSolicitud([FromBody] SolicitudModal Solicitud)
        {
            if (Solicitud == null)
                return BadRequest();

            if(Solicitud.Nombre == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre no puede estar vacio");
            }
            await db.InsertSolicitud(Solicitud);
            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSolicitud([FromBody] SolicitudModal solicitud, string id)
        {
            if (solicitud == null)
                return BadRequest();

            if(solicitud.Responsable == string.Empty && solicitud.Estado == string.Empty) 
            {
                ModelState.AddModelError("Nombre", "El nombre no puede estar vacion");
            }
            solicitud.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateSolicitud(solicitud);
            return Created("Creado", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSolicitud(string id)
        {
            await db.DeleteSolicitud(id);
            return NoContent();
        }
    }
}
