using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ClientController : Controller {

        public static IClientCollection collection = new ClientCollection ();

        [HttpGet]
        public async Task<IActionResult> getAll () {
            return Ok (await collection.GetAllClients ());
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> getById (string id) {
            return Ok (await collection.GetClientById (id));
        }

        [HttpPost]
        public async Task<IActionResult> createClient ([FromBody] Client client) {
            await collection.InsertClient (client);
            return Created ("Created", true);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> deleteClient (string id) {
            await collection.DeleteClient (id);
            return NoContent (); // success
        }

    }
}