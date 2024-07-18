using Microsoft.AspNetCore.Mvc;

namespace Service2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(){
            await Task.Delay(15000);
            return Ok(123);
        }
    }
}