using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSozluk_JWT.TokenDal;

namespace UniSozluk_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("",new BuildToken().CreateToken());
        }

        [Authorize]
        [HttpGet("[action]")] 
        public IActionResult Page1() 
        {
            return Ok("Sayfa 1 için girişiniz başarılı");
        }
    }
}
