using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLISEMRIHRController : ControllerBase
    {
        private readonly ITBLISEMRIHRRepository _repository;

        public TBLISEMRIHRController(ITBLISEMRIHRRepository repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetIsEmriHR")]
        public async Task<IActionResult> GetIsEmriHR([FromBody] TBLIsemrihrRequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName,
                    request.IsEmriKod
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
