using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneTicketService.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        UnityOfWork uow;
        public PlaneController(UnityOfWork uow)
        {
            this.uow = uow;
        }
        //[Route("Planes")]
        // GET: Planes
        [HttpGet(Name = "Planes")]
        public async Task<IActionResult> Planes()
        {
           try
            {
                var clients = await uow.Planes.RetrieveAll().ConfigureAwait(false);
                if (clients == null)
                {
                    return NotFound();
                }
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Plane/5
        [HttpGet("{id}", Name = "Plane")]
        public async Task<IActionResult> GetPlane(int id)
        {
            try
            {
                var nPlane = await uow.Planes.Retrieve(id).ConfigureAwait(false);
                if (nPlane == null)
                {
                    return NotFound();
                }
                return Ok(nPlane);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Plane
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Plane nPlane)
        {
            if (ModelState.IsValid)
            {
                var newPlane = await uow.Planes.Create(nPlane).ConfigureAwait(false);
                return Ok(newPlane);
            }
            return BadRequest();
        }

        // PUT: api/Plane/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Put([FromBody]Models.Plane nPlane, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == nPlane?.PlaneId)
                {
                    await uow.Planes.Update(nPlane).ConfigureAwait(false);
                    return Ok();
                }
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                result = await uow.Planes.Delete(id).ConfigureAwait(false);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
