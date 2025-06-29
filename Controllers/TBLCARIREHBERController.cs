using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLCARIREHBERController : ControllerBase
    {
        private readonly ITBLCARIREHBERRepository _repository;

        public TBLCARIREHBERController(ITBLCARIREHBERRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetCARIREHBER")]
        public async Task<IActionResult> GetCARIREHBER([FromBody] TBLCARIREHBERRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName,
                    request.gelen
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
