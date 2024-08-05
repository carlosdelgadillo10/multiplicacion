using Microsoft.AspNetCore.Mvc;

namespace MultiplicationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiplyController : ControllerBase
    {
        [HttpPost]
        public IActionResult Multiply([FromBody] MultiplicationRequest request)
        {
            if (request == null || request.Num1 == null || request.Num2 == null)
            {
                return BadRequest("Invalid input");
            }

            double num1 = (double)request.Num1;
            double num2 = (double)request.Num2;
            double result = num1 * num2;

            // Formatear el resultado a una cadena con un decimal
            string formattedResult = result.ToString("F1");

            return Ok(formattedResult);
        }
    }

    public class MultiplicationRequest
    {
        public double? Num1 { get; set; }
        public double? Num2 { get; set; }
    }
}
