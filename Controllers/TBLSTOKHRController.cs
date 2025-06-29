using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Repositories;
using MultiDbWebApi.Models;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLSTOKHRController : ControllerBase
    {
        private readonly ITBLSTOKHRRepository _repository;

        public TBLSTOKHRController(ITBLSTOKHRRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetStokHR")]
        public async Task<IActionResult> GetStokHR([FromBody] TBLStokhrRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName,
                    request.StokKod
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
