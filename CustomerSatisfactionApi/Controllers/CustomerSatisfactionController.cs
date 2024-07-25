using CustomerSatisfaction.Core;
using CustomerSatisfaction.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSatisfactionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerSatisfactionController : Controller
    {
        private readonly CustomerReviewService _service;

        public CustomerSatisfactionController(CustomerReviewService service)
        {
            _service = service;
        }

        // POST api/customersatisfaction/predict
        [HttpPost("predict")]
        public async Task<IActionResult> Predict([FromBody] ReviewInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.ReviewText))
            {
                return BadRequest("Review text is required.");
            }

            try
            {
                var score = await Task.FromResult(_service.PredictSatisfaction(input.ReviewText));
                return Ok(new { Score = score });
            }
            catch (Exception ex)
            {
                // Hata durumunu yönet
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
