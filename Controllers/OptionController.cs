using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csAmazen.Models;
using csAmazen.Repositories;
using csAmazen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csAmazen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OptionController : ControllerBase
  {
    private readonly OptionService _optionService;

    public OptionController(OptionService optionService)
    {
      _optionService = optionService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Option>> Create([FromBody] Option newOption)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newOption.CreatorId = userInfo.Id;

        Option created = _optionService.Create(newOption);

        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public ActionResult<IEnumerable<Option>> Get()
    {
      try
      {
        return Ok(_optionService.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<Option>> GetOne(int id)
    {
      try
      {
        return Ok(_optionService.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Option>> Edit(int id, [FromBody] Option editedOption)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editedOption.Id = id;
        return Ok(_optionService.Edit(editedOption, userInfo));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_optionService.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}