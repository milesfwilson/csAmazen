using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using csAmazen.Models;
using csAmazen.Repositories;

namespace csAmazen.Services
{
  public class OptionService
  {

    private readonly OptionRepository _repo;

    public OptionService(OptionRepository repo)
    {
      _repo = repo;
    }

    internal Option Create(Option newOption)
    {
      newOption.Id = _repo.Create(newOption);
      return newOption;
    }

    internal IEnumerable<Option> Get()
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

    internal Option GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    internal Option Edit(Option editedOption, Profile userInfo)
    {
      Option original = _repo.GetOne(editedOption.Id);
      if (original == null)
      {
        throw new Exception("Does not exist");
      }
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Access Denied");
      }
      _repo.Edit(editedOption);
      return _repo.GetOne(editedOption.Id);
    }

    internal object GetOptionsByItemId(int id)
    {
      return _repo.GetOptionsByItemId(id);
    }
  }
}