using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneTicketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        UnityOfWork uow;
        public TicketController(UnityOfWork uow)
        {
            this.uow = uow;
        }

       
        // GET: /Ticket
        [HttpGet]
        public async Task<IActionResult> Tickets()
        {
            try
            {
                var clients = await uow.Tickets.RetrieveAll().ConfigureAwait(false);
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
        [Route("Flights")]
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        public async Task<IActionResult> GetTicketFlights()
        {
            try
            {
                var clients = await uow.Tickets.GetTicketsWithFlight().ConfigureAwait(false);
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
        // GET: /Client/5
        [HttpGet("{id}", Name = "Ticket")]
        public async Task<IActionResult> GetTicket(int id)
        {
            try
            {
                var nClient = await uow.Tickets.Retrieve(id).ConfigureAwait(false);
                if (nClient == null)
                {
                    return NotFound();
                }
                return Ok(nClient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Client
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Ticket nClient)
        {
            if (ModelState.IsValid)
            {
                var newClient = await uow.Tickets.Create(nClient).ConfigureAwait(false);
                return Ok(newClient);
            }
            return BadRequest();

        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Ticket nClient)
        {
            if (ModelState.IsValid)
            {
                if (id == nClient.TicketId)
                {
                    await uow.Tickets.Update(nClient).ConfigureAwait(false);
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
                result = await uow.Tickets.Delete(id).ConfigureAwait(false);
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
