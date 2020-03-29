using Microsoft.AspNetCore.Mvc;

namespace DefaultAspNetCoreTemplate.Controller {
    
    [Route("api/[controller]")]
    public class DemoDataController : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok("Hello World!");
        }
        
    }
}