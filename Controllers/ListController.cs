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
  public class ListController : ControllerBase
  {
    private readonly ListService _listService;

    private readonly ListItemService _listItemService;

    public ListController(ListService listService, ListItemService listItemService)
    {
      _listService = listService;
      _listItemService = listItemService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<List>> Create([FromBody] List newList)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newList.CreatorId = userInfo.Id;
        List created = _listService.Create(newList);
        newList.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public async Task<ActionResult<List>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();

        return Ok(_listService.Get(userInfo.Id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<List>> GetOne(int id)
    {
      try
      {
        return Ok(_listService.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{id}/listitem")]

    public ActionResult<IEnumerable<List>> GetItemsByListId(int id)
    {
      try
      {
        return Ok(_listItemService.GetItemsByListId(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<List>> Edit(int id, [FromBody] List editedList)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editedList.Id = id;
        return Ok(_listService.Edit(editedList, userInfo));
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
        return Ok(_listService.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}