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
  public class ItemController : ControllerBase
  {
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
      _itemService = itemService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Item>> Create([FromBody] Item newItem)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newItem.CreatorId = userInfo.Id;
        Item created = _itemService.Create(newItem);
        newItem.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public ActionResult<IEnumerable<Item>> Get()
    {
      try
      {
        return Ok(_itemService.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<Item>> GetOne(int id)
    {
      try
      {
        return Ok(_itemService.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_itemService.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}