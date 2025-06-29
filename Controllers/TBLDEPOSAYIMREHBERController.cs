using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLDEPOSAYIMREHBERController : ControllerBase
    {
        private readonly ITBLDEPOSAYIMREHBERRepository _repository;

        public TBLDEPOSAYIMREHBERController(ITBLDEPOSAYIMREHBERRepository repository)
        {
            _repository = repository;
        }
        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetDepoSayimRehber")]
        public async Task<IActionResult> GetDepoSayimRehber([FromBody] TBLSTOKREHBERRequestDto request)
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
