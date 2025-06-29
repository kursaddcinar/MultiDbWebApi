using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Repositories;
using MultiDbWebApi.Models;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLURETIMController2 : ControllerBase
    {
        private readonly ITBLURETIMRepository2 _repository;

        public TBLURETIMController2(ITBLURETIMRepository2 repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetUretim2")]
        public async Task<IActionResult> GetUretim2([FromBody] TBLUretim2RequestDto request)
        {
            try
            {
                // Stored Procedure çağrısı
                var result = await _repository.ExecuteStoredProcedureAsync(
                    request.DatabaseName,
                    request.UretimKod
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
