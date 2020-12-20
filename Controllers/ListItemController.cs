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
  public class ListItemController : ControllerBase
  {
    private readonly ListItemService _listItemService;

    public ListItemController(ListItemService listItemService)
    {
      _listItemService = listItemService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ListItem>> Create([FromBody] ListItem newListItem)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newListItem.CreatorId = userInfo.Id;
        ListItem created = _listItemService.Create(newListItem);
        newListItem.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public ActionResult<IEnumerable<ListItem>> Get()
    {
      try
      {
        return Ok(_listItemService.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<ListItem>> GetOne(int id)
    {
      try
      {
        return Ok(_listItemService.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<ListItem>> Edit(int id, [FromBody] ListItem editedListItem)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editedListItem.Id = id;
        return Ok(_listItemService.Edit(editedListItem, userInfo));
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
        return Ok(_listItemService.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}