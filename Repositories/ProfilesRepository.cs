using System.Data;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace Keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile newProfile)
    {
      string sql = @"
            INSERT INTO profiles
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, newProfile);
      return newProfile;
    }
    internal IEnumerable<Vault> GetVaultsByCreatorId(string creatorId)
    {
      string sql = @"
    SELECT
    vault.*,
    profile.* 
    FROM vaults vault 
    JOIN profiles profile on vault.creatorId = profile.Id
    WHERE vault.creatorId = creatorId
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, splitOn: "id");
    }
  }
}