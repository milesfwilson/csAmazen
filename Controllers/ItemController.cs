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
    private readonly OptionService _optionService;

    public ItemController(ItemService itemService, OptionService optionService)
    {
      _itemService = itemService;
      _optionService = optionService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Item>> Create([FromBody] Item newItem)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newItem.CreatorId = userInfo.Id;
        if (newItem.SalePrice == 0)
        {
          newItem.SalePrice = newItem.Price;
        }
        Item created = _itemService.Create(newItem);
        created.Creator = userInfo;
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

    [HttpGet("{id}/option")]
    public ActionResult<IEnumerable<Option>> GetOptionsByItemId(int id)
    {
      try
      {
        return Ok(_optionService.GetOptionsByItemId(id));
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Item>> Edit(int id, [FromBody] Item editedItem)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editedItem.Id = id;
        return Ok(_itemService.Edit(editedItem, userInfo));
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
        return Ok(_itemService.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}