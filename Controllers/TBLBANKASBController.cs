using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Repositories;
using MultiDbWebApi.Models;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLBANKASBController : ControllerBase
    {
        private readonly ITBLBANKASBRepository _repository;

        public TBLBANKASBController(ITBLBANKASBRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetBankaSB")]
        public async Task<IActionResult> GetBankaSB([FromBody] TBLBankaRequestDto request)
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
