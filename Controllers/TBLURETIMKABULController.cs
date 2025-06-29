using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;

namespace MultiDbWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBLURETIMKABULController : ControllerBase
    {
        private readonly ITBLURETIMKABULRepository _repository;

        public TBLURETIMKABULController(ITBLURETIMKABULRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteFPROCOPRSAVE([FromBody] TBLURETIMKABULRequestDto requestDto)
        {
            if (requestDto == null)
                return BadRequest("Request data is missing.");

            try
            {
                bool isExecuted = await _repository.ExecuteFPROCOPRSAVEAsync(requestDto);

                if (isExecuted)
                    return Ok(new { message = "Procedure executed successfully." });
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "No rows were affected.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

    }
}

