using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLSTOKREHBERController : ControllerBase
    {
        private readonly ITBLSTOKREHBERRepository _repository;

        public TBLSTOKREHBERController(ITBLSTOKREHBERRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetStokREHBER")]
        public async Task<IActionResult> GetStokREHBER([FromBody] TBLSTOKREHBERRequestDto request)
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
