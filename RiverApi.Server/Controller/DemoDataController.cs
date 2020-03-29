using Microsoft.AspNetCore.Mvc;

namespace RiverApi.Server.Controller {
    
    [Route("api/[controller]")]
    public class DemoDataController : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok("Hello World!");
        }
        
    }
}