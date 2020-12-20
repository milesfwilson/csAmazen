using System;
using System.Collections.Generic;
using csAmazen.Models;
using csAmazen.Repositories;

namespace csAmazen.Services
{
  public class ListItemService
  {

    private readonly ListItemRepository _repo;

    public ListItemService(ListItemRepository repo)
    {
      _repo = repo;
    }

    internal ListItem Create(ListItem newListItem)
    {
      newListItem.Id = _repo.Create(newListItem);
      return newListItem;
    }

    internal IEnumerable<ListItem> Get()
    {
      return _repo.Get();
    }

    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      return "Unable to be deleted";
    }

    internal ListItem GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    internal ListItem Edit(ListItem editedListItem, Profile userInfo)
    {
      ListItem original = _repo.GetOne(editedListItem.Id);
      if (original == null)
      {
        throw new Exception("Does not exist");
      }
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Access Denied");
      }
      _repo.Edit(editedListItem);
      return _repo.GetOne(editedListItem.Id);
    }

    internal object GetItemsByListId(int id)
    {
      return _repo.GetItemsByListId(id);
    }
  }
}