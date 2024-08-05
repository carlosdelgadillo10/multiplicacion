using Microsoft.AspNetCore.Mvc;

namespace MultiplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiplicationController : ControllerBase
    {
        public class MultiplicationRequest
        {
            public double Num1 { get; set; }
            public double Num2 { get; set; }
        }

        [HttpPost]
        public IActionResult Multiply([FromBody] MultiplicationRequest request)
        {
            double result = request.Num1 * request.Num2;
            return Ok(result);
        }
    }
}
