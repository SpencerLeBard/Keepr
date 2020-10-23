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
        INSERT INTO keeps 
        (name , description, img , views , shares , keeps , creatorId)
        VALUES
        (@Name , @Description , @Img , @Views , @Shares , @Keeps , @CreatorId);
        SELECT LAST_INSERT_ID;";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile on keep.creatorId = profile.Id
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
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
  }
}