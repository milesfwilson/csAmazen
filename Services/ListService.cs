using System;
using System.Collections.Generic;
using csAmazen.Models;
using csAmazen.Repositories;

namespace csAmazen.Services
{
  public class ListService
  {

    private readonly ListRepository _repo;

    public ListService(ListRepository repo)
    {
      _repo = repo;
    }

    internal List Create(List newList)
    {
      newList.Id = _repo.Create(newList);
      return newList;
    }

    internal IEnumerable<List> Get(string profileId)
    {
      return _repo.Get(profileId);
    }

    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      return "Unable to be deleted";
    }

    internal List GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    internal List Edit(List editedList, Profile userInfo)
    {
      List original = _repo.GetOne(editedList.Id);
      if (original == null)
      {
        throw new Exception("Does not exist");
      }
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Access Denied");
      }
      _repo.Edit(editedList);
      return _repo.GetOne(editedList.Id);
    }
  }
}