using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Repositories;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _serv;
    public VaultKeepsController(VaultKeepsService serv)
    {
      _serv = serv;
    }

    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVK)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVK.CreatorId = userInfo.Id;
        _serv.Create(newVK);
        return Ok("nice job");
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _serv.Delete(id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //NOTE GET KEEPS BY VAULT ID
    [HttpGet("{vaultId}")] //Path: api/vaultkeeps/:vaultId
    public async Task<ActionResult<VaultKeep>> GetKeepsByVaultById(int vaultId)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        IEnumerable<Keep> res = (IEnumerable<Keep>)_serv.GetKeepsByVaultId(userInfo?.Id, vaultId);
        return Ok(res);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}