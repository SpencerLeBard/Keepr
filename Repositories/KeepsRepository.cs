using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    //NOTE POPULATE HERE
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO Keeps 
        (name , description, img , shares , views , keeps , creatorId)
        VALUES
        (@Name , @Description , @Img , @Views , @Shares , @Keeps , @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT 
      keep.*,
      prof.*
      FROM keeps keep
      JOIN profiles prof ON keep.creatorId = prof.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, splitOn: "id");
    }
    internal Keep GetById(int id)
    {
      string sql =
      @"
      SELECT
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile on keep.creatorId = profile.Id
      WHERE keep.id = @id
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id").FirstOrDefault();
    }
    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    //NOTE AS = rename column or table with alias
    //JOIN = combine rows from two or more tables, based on a related column between them (ven diagram)
    //specify which table to select
    {
      string sql = @"
      SELECT k.*, vk.id 
      AS VaultKeepId , p.*
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN profiles p ON k.creatorId = p.id
      WHERE vaultId = @id
      ";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id");
    }
    internal void Remove(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
    internal Keep KeepViewCounter(Keep keepData)
    {
      string sql = @"
            UPDATE keeps
            SET
            views = @Views + 1
            WHERE id = @Id;";
      _db.Execute(sql, keepData);
      return keepData;
    }
    internal Keep KeepsCounter(Keep keepData)
    {
      string sql = @"
            UPDATE keeps
            SET
            keeps = @Keeps + 1
            WHERE id = @Id;";
      _db.Execute(sql, keepData);
      return keepData;
    }
    internal IEnumerable<Keep> GetKeepsByCreatorId(string queryProfile)
    {
      string sql = @"
    SELECT
    keep.*,
    profile.* 
    FROM keeps keep 
    JOIN profiles profile on keep.creatorId = profile.Id
    WHERE keep.creatorId = @queryProfile
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { queryProfile }, splitOn: "id");
    }
  }
}