using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLCEKSENETwithSERIALController : ControllerBase
    {
        private readonly ITBLCEKSENETwithSERIALRepository _repository;

        public TBLCEKSENETwithSERIALController(ITBLCEKSENETwithSERIALRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetCekSenetWithSerial")]
        public async Task<IActionResult> GetCekSenetWithSerial([FromBody] TBLCekSenetWithSerialRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(request.DatabaseName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
