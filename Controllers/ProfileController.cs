using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csAmazen.Models;
using csAmazen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csAmazen.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly ProfileService _ps;

    public ProfileController(ProfileService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));

      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);
      }
    }

  }
}