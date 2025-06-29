using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;

namespace MultiDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBLSTOKSBController2 : ControllerBase
    {
        private readonly ITBLSTOKSBRepository2 _repository;

        public TBLSTOKSBController2(ITBLSTOKSBRepository2 repository)
        {
            _repository = repository;
        }

        // JSON Body'den parametre alacak şekilde düzenlendi
        [HttpPost("GetStokSB2")]
        public async Task<IActionResult> GetStokSB2([FromBody] TBLStoksbRequestDto2 request)
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
