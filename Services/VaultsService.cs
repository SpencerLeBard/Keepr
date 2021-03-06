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

    //NOTE
    //if current user.id = profile show everything
    //else show all vaults where is private = false
    internal IEnumerable<Vault> GetVaultsByCreatorId(string queryProfile, string creatorId)
    {
      IEnumerable<Vault> VaultsByCreatorId = _repo.GetVaultsByCreatorId(queryProfile);
      if (queryProfile != creatorId)
      {
        return VaultsByCreatorId.ToList().FindAll(v => v.IsPrivate == false);
      }
      return VaultsByCreatorId;
    }
    // internal IEnumerable<Vault> GetVaultsByCreatorId(string queryProfile, string creatorId)
    // {
    //   return _repo.GetVaultsByCreatorId(queryProfile).ToList().FindAll(v => v.CreatorId == creatorId || v.IsPrivate == false);
    // }




    // internal IEnumerable<Vault> GetVaultsByCreatorId(string queryProfile, string creatorId)
    // {
    //   if(creatorId.id == ){
    //   return _repo.GetVaultsByCreatorId(queryProfile).ToList().FindAll();
    //   }
    //   else{
    //     _repo.GetVaultsByCreatorId(queryProfile).ToList().FindAll();
    //   }
    // }

    internal object Delete(int id, string creatorId)
    {
      Vault original = _repo.GetById(id);
      // if (original == null) { throw new Exception("Invalid Id"); }
      // if (original.CreatorId != creatorId) { throw new Exception("Access Denied... This is not yours"); }
      _repo.Remove(id);
      return "succesfully delorted";

    }
  }
}