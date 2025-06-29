using Microsoft.AspNetCore.Mvc;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;

namespace MultiDbWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBLPANELKALITEController : Controller
    {
        private readonly TBLKALITEKONTROLRepository _repository;
        public TBLPANELKALITEController(TBLKALITEKONTROLRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("PanelKontrol")]
        public async Task<IActionResult> ExecuteFPPanelKaliteSave([FromBody] TBLKALITEKONTROL tb)
        {
            if (tb == null)
                return BadRequest("Request data is missing.");

            try
            {
                bool isExecuted =  await _repository.AddPanelKaliteAsync(tb);

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
