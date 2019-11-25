using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneTicketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClient client;
        public ClientController(IClient _client)
        {
            client = _client;
        }
        [Route("GetClients")]

        // GET: /Client
        [HttpGet]
        public async Task<ActionResult<Client>> GetClients()
        {
            try
            {
                var clients = await client.GetClients().ConfigureAwait(false);
                if(clients == null)
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
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var nClient = await client.GetClient(id).ConfigureAwait(false);
                if(nClient == null)
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
        public async Task<ActionResult<Client>> Post([FromBody]Models.Client nClient)
        {
            if (ModelState.IsValid)
            {
                var newClient = await client.AddClient(nClient).ConfigureAwait(false);
                return Ok(newClient);
            }
            return BadRequest();

        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Models.Client nClient)
        {
            if (ModelState.IsValid)
            {
                if (id == nClient.ClientId)
                {
                    await client.UpdateClient(nClient).ConfigureAwait(false);
                    return Ok();
                }
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            int result = 0;
            if(id == 0)
            {
                return BadRequest();
            }
            try
            {
                result = await client.DeleteClient(id).ConfigureAwait(false);
                if(result == 0)
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
