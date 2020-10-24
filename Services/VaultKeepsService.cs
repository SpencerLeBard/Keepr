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

  }
}