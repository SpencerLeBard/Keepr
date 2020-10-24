using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    //NOTE POPULATE HERE
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}