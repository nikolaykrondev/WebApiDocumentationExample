using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDocumentationExample.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckAccessController : ControllerBase
{
    [HttpGet(template: "GetAdmin")]
    [Authorize(Policy = "OnlyAdmin")]
    public IActionResult GetAdmin()
    {
        var jwt = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        
        return Ok(new {Username = "Admin", Jwt = jwt});
    }
    
    [HttpGet(template: "GetRegularUser")]
    [Authorize(Policy = "RegularUser")]
    public IActionResult GetRegularUser()
    {
        return Ok("RegularUser");
    }
}