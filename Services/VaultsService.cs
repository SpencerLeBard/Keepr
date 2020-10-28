using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    internal Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }
    internal Vault GetById(string creatorId, int id)
    {
      Vault original = _repo.GetById(id);
      // if (original == null)
      // {
      //   throw new Exception("Invalid ID");
      // }
      // if (original.CreatorId != creatorId)
      // {
      //   throw new Exception("Access Denied, why u lie about id");
      // }
      //NOTE WHY KEEP THROWING ACCESS DENIED
      return original;
    }
    internal IEnumerable<Vault> GetVaultsByCreatorId(string queryProfile, string creatorId)
    {
      return _repo.GetVaultsByCreatorId(queryProfile).ToList().FindAll(v => v.CreatorId == creatorId || v.IsPrivate == false);
    }

    internal object Delete(int id, string creatorId)
    {
      Vault original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != creatorId) { throw new Exception("Access Denied... This is not yours"); }
      _repo.Remove(id);
      return "succesfully delorted";

    }
  }
}