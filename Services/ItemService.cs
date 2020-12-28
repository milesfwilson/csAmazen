using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
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
      return _repo.Get().ToList().FindAll(item => item.IsAvailable);
    }

    internal IEnumerable<Item> GetItemsByProfile(string profileId, string userId)
    {

      return _repo.getItemsByProfile(profileId).ToList().FindAll(item => item.CreatorId == userId || item.IsAvailable);
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

    internal Item Edit(Item editedItem, Profile userInfo)
    {
      Item original = _repo.GetOne(editedItem.Id);
      if (original == null)
      {
        throw new Exception("Does not exist");
      }
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Access Denied");
      }
      _repo.Edit(editedItem);
      return _repo.GetOne(editedItem.Id);
    }
  }
}