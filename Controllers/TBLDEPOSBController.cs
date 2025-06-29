using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Repositories;
using MultiDbWebApi.Models;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLDEPOSBController : ControllerBase
    {
        private readonly ITBLDEPOSBRepository _repository;

        public TBLDEPOSBController(ITBLDEPOSBRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetDepoSB")]
        public async Task<IActionResult> GetDepoSB([FromBody] TBLDepoRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
