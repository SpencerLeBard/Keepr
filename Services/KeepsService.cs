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

    internal IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
    }
    //NOTE FURST TRY
    // internal IEnumerable<Keep> GetAll(string CreatorId)
    // {
    //   IEnumerable<Keep> keeps = _repo.GetAll();
    //   return keeps.ToList().FindAll(k => k.CreatorId == CreatorId);
    //   //NOTE ADD SOMETHING AFTER CREATOR ID || IF PUBLIC/SHARED
    // }
    internal Keep GetById(string creatorId, int id)
    {
      Keep original = _repo.GetById(id);
      if (original == null)
      {
        throw new Exception("Invalid ID");
      }
      if (original.CreatorId != creatorId)
      {
        throw new Exception("Access Denied, why u lie about id");
      }
      //NOTE WHY KEEP THROWING ACCESS DENIED
      return original;
    }
    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }
    internal object Delete(int id, string creatorId)
    {
      Keep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      // if (original.CreatorId != creatorId) { throw new Exception("Access Denied... This is not yours"); }
      _repo.Remove(id);
      return "succesfully delorted";

    }

    internal Keep KeepCounter(Keep keepData, string creatorId)
    {
      Keep original = _repo.GetById(keepData.Id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != creatorId) { throw new Exception("Access Denied... This is not yours"); }
      // keepData.Name = keepData.Name == null ? original.Name : keepData.Name;
      // keepData.Description = keepData.Description == null ? original.Description : keepData.Description;
      // keepData.Img = keepData.Img == null ? original.Img : keepData.Img;
      //NOTE LOGIC FOR COUNTER HERE

      return _repo.KeepCounter(keepData);
    }

  }
}