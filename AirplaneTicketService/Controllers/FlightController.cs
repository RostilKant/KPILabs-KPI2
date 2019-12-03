using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneTicketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        UnityOfWork uow;
        public FlightController(UnityOfWork uow)
        {
            this.uow = uow;
        }
        // GET: api/Flight
        [HttpGet]
        public async Task<IActionResult> Flights()
        {
            try
            {
                var flights = await uow.Flights.RetrieveAll().ConfigureAwait(false);
                if (flights == null)
                {
                    return NotFound();
                }
                return Ok(flights);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("Departure")]
        [HttpGet]
        public async Task<IActionResult> Flights(string airport)
        {
            try
            {
                var clients = await uow.Flights.GetFlightsByDeparture(airport).ConfigureAwait(false);
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
        // GET: api/Flight/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetFlight(int id)
        {
            try
            {
                var nClient = await uow.Flights.Retrieve(id).ConfigureAwait(false);
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

        // POST: api/Flight
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Flight nflight )
        {
            if (ModelState.IsValid)
            {
                var newFlight = await uow.Flights.Create(nflight).ConfigureAwait(false);
                return Ok(newFlight);
            }
            return BadRequest();
        }

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Flight nFlight)
        {
            if (ModelState.IsValid)
            {
                if (id == nFlight.FlightId)
                {
                    await uow.Flights.Update(nFlight).ConfigureAwait(false);
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
                result = await uow.Flights.Delete(id).ConfigureAwait(false);
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
