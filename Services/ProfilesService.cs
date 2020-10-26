using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }
    internal Profile GetProfileById(string id)
    {
      return _repo.GetById(id);
    }
    internal IEnumerable<Vault> Get(string creatorId)
    {
      return _repo.GetVaultsByCreatorId(creatorId).ToList().FindAll(v => v.CreatorId == creatorId);
      //NOTE ADD || PRIVATE == FALSE
    }

  }
}