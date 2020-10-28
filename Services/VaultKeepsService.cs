using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    internal void Create(VaultKeep newVK)
    {
      _repo.Create(newVK);
    }
    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
    internal IEnumerable<Keep> GetKeepsByVaultId(string creatorId, int vaultId)
    {
      IEnumerable<Keep> original = _repo.GetKeepsByVaultId(vaultId);
      // if (original == null)
      // {
      //   throw new Exception("Invalid ID");
      // }
      return original;
    }
  }
}