using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLRECETEHRController : ControllerBase
    {
        private readonly ITBLRECETEHRRepository _repository;

        public TBLRECETEHRController(ITBLRECETEHRRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetReceteHR")]
        public async Task<IActionResult> GetReceteHR([FromBody] TBLRecetehrRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName,
                    request.ReceteKod
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
