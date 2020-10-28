using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    //NOTE POPULATE HERE
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal int Create(Vault newVault)
    {
      string sql = @"
        INSERT INTO vaults 
        (name , description, isPrivate , creatorId)
        VALUES
        (@Name , @Description , @isPrivate , @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }
    internal Vault GetById(int id)
    {
      string sql =
      @"
      SELECT
      vault.*,
      profile.*
      FROM vaults vault
      JOIN profiles profile on vault.creatorId = profile.Id
      WHERE vault.id = @id
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { id }, splitOn: "id").FirstOrDefault();
    }
    internal IEnumerable<Vault> GetVaultsByCreatorId(string queryProfile)
    {
      string sql = @"
    SELECT
    vault.*,
    profile.* 
    FROM vaults vault 
    JOIN profiles profile on vault.creatorId = profile.Id
    WHERE vault.creatorId = @queryProfile
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { queryProfile }, splitOn: "id");
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}