using System;
using System.Collections.Generic;
using csAmazen.Models;
using csAmazen.Repositories;

namespace csAmazen.Services
{
  public class ItemService
  {

    private readonly ItemRepository _repo;

    public ItemService(ItemRepository repo)
    {
      _repo = repo;
    }

    internal Item Create(Item newItem)
    {
      newItem.Id = _repo.Create(newItem);
      return newItem;
    }

    internal IEnumerable<Item> Get()
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

    internal Item GetOne(int id)
    {
      return _repo.GetOne(id);
    }
  }
}