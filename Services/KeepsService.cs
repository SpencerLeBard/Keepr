using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {

    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }
    internal IEnumerable<Keep> GetAll(string CreatorId)
    {
      IEnumerable<Keep> keeps = _repo.GetAll();
      return keeps.ToList().FindAll(k => k.CreatorId == CreatorId);
      //NOTE ADD SOMETHING AFTER CREATOR ID || IF PUBLIC/SHARED
    }
  }
}