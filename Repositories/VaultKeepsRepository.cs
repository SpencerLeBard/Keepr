using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal void Create(VaultKeep newVK)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId , keepId , creatorId)
      VALUES
      (@VaultId , @KeepId , @CreatorId);
      ";
      _db.Execute(sql, newVK);
    }
    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT * 
      FROM vaultkeeps vk
      INNER JOIN keeps k 
      ON k.id = vk.keepId
      WHERE vaultId = @vaultId;
      ";
      var result = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { vaultId }, splitOn: "id");
      return result;
    }
  }
}