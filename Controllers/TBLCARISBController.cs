using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Repositories;
using MultiDbWebApi.Models;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLCARISBController : ControllerBase
    {
        private readonly ITBLCARISBRepository _repository;

        public TBLCARISBController(ITBLCARISBRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetCariSB")]
        public async Task<IActionResult> GetCariSB([FromBody] TBLCarisbRequestDto request)
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
