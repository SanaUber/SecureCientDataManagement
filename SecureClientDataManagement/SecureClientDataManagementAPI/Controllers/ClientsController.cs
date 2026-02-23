using Microsoft.AspNetCore.Mvc;
using SecureCientDataManagementAPI.Interfaces;
using SecureCientDataManagementAPI.Models;
using SecureCientDataManagementAPI.Services;

namespace SecureCientDataManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // POST: api/Clients - ??? ??????? ??????
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid client data");

            await _service.AddClientAsync(dto);
            return Ok("Client added successfully");
        }

        // GET: api/Clients - ???? ????????? ?? ?????
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAllClientsAsync();
            return Ok(clients);
        }

        // GET: api/Clients/{id}/decrypt - ?? ??????? ?? Emirates ID decrypt ???? ??????
        [HttpGet("{id}/decrypt")]
        public async Task<IActionResult> Decrypt(int id)
        {
            try
            {
                var decrypted = await _service.GetDecryptedEmiratesIdAsync(id);
                return Ok(decrypted);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Client not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Decryption error: {ex.Message}");
            }
        }
    }
}