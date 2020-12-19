using System;
using csAmazen.Models;
using csAmazen.Repositories;

namespace csAmazen.Services
{
  public class ProfileService
  {

    private readonly ProfileRepository _repo;

    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }

    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile foundProfile = _repo.GetById(userInfo.Id);
      if (foundProfile == null)
      {
        return _repo.Create(userInfo);
      }
      return foundProfile;

    }
  }
}